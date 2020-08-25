using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinForms.FloatingButton
{
    public partial class FloatingButton : ContentView
    {
        #region CommandProperty

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: nameof(Command),
                returnType: typeof(ICommand),
                declaringType: typeof(FloatingButton));

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
                declaringType: typeof(FloatingButton),
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
                declaringType: typeof(FloatingButton),
                defaultValue: Color.Black);

        public new Color BackgroundColor
        {
            get => (Color) GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
        
        #endregion

        public event EventHandler Clicked; 
        
        public FloatingButton()
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

        private void Page_Appearing(object sender, EventArgs e)
        {
            Button.Scale = 0;
            Button.ScaleTo(1, easing: Easing.SpringOut);
        }

        private void Page_Disappearing(object sender, EventArgs e)
        {
            // Button.Scale = 0;
            // sprawdzic na Androidzie WordPress jak wyglada animacja FloatingButtona przy wychodzeniu z widoku
            Button.ScaleTo(0, easing: Easing.SpringOut);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
