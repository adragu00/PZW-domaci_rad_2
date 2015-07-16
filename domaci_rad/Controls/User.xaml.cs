using System.Windows;
using System.Windows.Controls;

namespace domaci_rad.Controls
{
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }


        // dependency property for image source
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register
        (
          "ImageSource",
          typeof(string),
          typeof(User),
          new UIPropertyMetadata("ImageSource")
        );


        // dependency property for user name
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register
        (
          "UserName",
          typeof(string),
          typeof(User),
          new UIPropertyMetadata("UserName")
        );


        // delete
        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

       /* private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
        }
        */

        // edit
        /*public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
           "Edit", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(User) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(User.EditEvent);
            RaiseEvent(newEventArgs);
        }*/

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
            //this.EditIcon.MouseDown += (obj, eventHandler) => RaiseEditEvent();
        }
    }
}
