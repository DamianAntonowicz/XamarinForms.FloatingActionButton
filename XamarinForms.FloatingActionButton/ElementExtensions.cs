using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForms
{
    public static class ElementExtensions
    {
        public static async Task<TParent> GetParentAsync<TParent>(this Element element)
            where TParent : Element
        {
            if (element is TParent)
            {
                return (TParent)element;
            }

            do
            {
                if (element.Parent != null)
                {
                    element = element.Parent;
                    continue;
                }

                var semaphore = new SemaphoreSlim(initialCount: 0);

                void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
                {
                    if (args.PropertyName == nameof(element.Parent) &&
                        element.Parent != null)
                    {
                        semaphore.Release();
                        element.PropertyChanged -= OnElementPropertyChanged;
                    }
                }

                element.PropertyChanged += OnElementPropertyChanged;

                await semaphore.WaitAsync();
            } while (!(element is TParent));

            return (TParent) element;
        }
    }
}