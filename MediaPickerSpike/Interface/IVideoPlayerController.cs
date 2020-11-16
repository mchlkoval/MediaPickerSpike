using MediaPickerSpike.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPickerSpike.Interface
{
    public interface IVideoPlayerController
    {
        VideoStatus Status { get; set; }
        TimeSpan Duration { get; set; }
    }
}
