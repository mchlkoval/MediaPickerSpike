using MediaPickerSpike.Abstract;
using MediaPickerSpike.Extension;
using MediaPickerSpike.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MediaPickerSpike.ViewModel
{
    public class CaptureVideoViewModel : BaseViewModel
    {
        private INavigation navigation;

        private UserVideo video;
        private UriVideoSource fullPath;
        public UriVideoSource FullPath {
            get {
                return fullPath;
            } set {
                fullPath = value;
                RaisePropertyChanged(() => FullPath);
            }
        }
        public UserVideo Video {
            get {
                return video;
            } set {

                if(video == value)
                {
                    return;
                }

                video = value;
                FullPath = new UriVideoSource {
                    Uri = video.FullPath
                };
                RaisePropertyChanged(() => Video);
                //SelectVideo();
            }
        }

        private ObservableCollection<UserVideo> videos = new ObservableCollection<UserVideo>();
        public ObservableCollection<UserVideo> Videos {
            get {
                return videos;
            } set {
                videos = value;
                RaisePropertyChanged(() => Videos);
            }
        }

        public ICommand CaptureVideoCommand => new Command(x => CaptureVideo());

        public CaptureVideoViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        private async void CaptureVideo()
        {
            ///data/user/0/com.companyname.mediapickerspike/files/ed3f5961-4554-4a3f-ba3d-dd44020745562062848124215052442.mp4
            try
            {
                var video = await MediaPicker.CaptureVideoAsync(new MediaPickerOptions {
                    Title = "Record Video"    
                });

                var stream = await video.OpenReadAsync();
                
                var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var localPath = Path.Combine(documentPath, video.FileName);
                File.WriteAllBytes(localPath, stream.ReadAllBytes());
                Videos.Add(new UserVideo
                {
                    FullPath = localPath,
                    VideoId = video.FileName,
                    Name = $"Test Video {Videos.Count}"
                });
                
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SelectVideo()
        {
            var fileExists = File.Exists(video.FullPath);
            Console.WriteLine(fileExists);
        }
    }
}
