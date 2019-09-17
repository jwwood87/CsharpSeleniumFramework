

namespace UdemyFramework.Common
{
    public interface INavigatePage
    {
        bool? IsVisible { get; }

        void GoTo();
    }
}
