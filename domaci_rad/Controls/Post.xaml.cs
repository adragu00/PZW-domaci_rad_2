using System.Windows;
using System.Windows.Controls;

namespace domaci_rad.Controls
{
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();
        }


        // dependency property for post text
        public string PostText
        {
            get { return (string)GetValue(PostTextProperty); }
            set { SetValue(PostTextProperty, value); }
        }

        public static readonly DependencyProperty PostTextProperty = DependencyProperty.Register
        (
          "PostText",
          typeof(string),
          typeof(Post),
          new UIPropertyMetadata("PostText")
        );


        // delete
        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }

        // edit
        /*public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
           "Edit", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Edit //za registraciju/deregistraciju 
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }

        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }*/

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            //this.EditIcon.MouseDown += (obj, eventHandler) => RaiseEditEvent();
            this.DeleteIcon.MouseDown += (obj, eventHandler) => RaiseDeleteEvent();
        }
    }
}
