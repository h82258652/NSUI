using System;

namespace NSUI.Controls
{
    public interface INSFocusVisual
    {
        Uri ShakeAudioSource { get; set; }

        double StrokeThickness { get; set; }

        void ShakeDown();

        void ShakeLeft();

        void ShakeRight();

        void ShakeUp();
    }
}