using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace XamarinForms.FloatingButton
{
    public partial class FloatingActionButton : ContentView
    {
        #region CommandProperty

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(FloatingActionButton));

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        #endregion
        
        #region TextColorProperty

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
                propertyName: nameof(TextColor),
                returnType: typeof(Color),
                declaringType: typeof(FloatingActionButton),
                defaultValue: Color.White);

        public Color TextColor
        {
            get => (Color) GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        
        #endregion
        
        #region BackgroundColorProperty

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(
                propertyName: nameof(BackgroundColor),
                returnType: typeof(Color),
                declaringType: typeof(FloatingActionButton),
                defaultValue: Color.Black);

        public new Color BackgroundColor
        {
            get => (Color) GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
        
        #endregion

        public event EventHandler Clicked; 
        
        public FloatingActionButton()
        {
            InitializeComponent();
        }

        protected override async void OnParentSet()
        {
            base.OnParentSet();
            
            var page = await this.GetParentAsync<Page>();

            page.Appearing += Page_Appearing;
            page.Disappearing += Page_Disappearing;
        }

        private async void Page_Appearing(object sender, EventArgs e)
        {
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                await Task.Delay(300);
            }

            await Shadows.ScaleTo(1, easing: Easing.SpringOut);
        }

        private void Page_Disappearing(object sender, EventArgs e)
        {
            Shadows.ScaleTo(0, easing: Easing.SpringIn);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);

            if (Command != null &&
                Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }
    }
}
