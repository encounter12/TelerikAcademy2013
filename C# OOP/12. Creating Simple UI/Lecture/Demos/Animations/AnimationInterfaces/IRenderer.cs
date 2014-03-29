using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Animations.AnimationInterfaces
{
    public interface IRenderer
    {
        void Render(object obj);

        void Clear();
    }
}