using System;
using System.Windows;
using System.Windows.Media;

using domaci_rad.Controls;

namespace domaci_rad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.AddLeftButton.Click += new RoutedEventHandler(AddLeftButton_Click);
            this.AddRightButton.Click += new RoutedEventHandler(AddRightButton_Click);

            foreach (var child in this.LeftContainer.Children)
            {
                if (!(child is User)) { continue; }

                var user = child as User;
                user.Delete += OnUserDelete;
                //user.Edit += OnUserEdit;
            }
            this.CurrentUser.Delete += OnCurrentUserDelete;

            foreach (var child in this.RightContainer.Children)
            {
                if (!(child is Post)) { continue; }

                var post = child as Post;
                post.Delete += OnPostDelete;
                //post.Edit += OnPostEdit;
            }
        }

        private void OnCurrentUserDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }

            var user = sender as User;

            MessageBox.Show("You can't delete yourself!");
        }

        void OnUserDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }

            var user = sender as User;

            this.LeftContainer.Children.Remove(user);
        }

        void OnPostDelete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }

            var post = sender as Post;

            this.RightContainer.Children.Remove(post);
        }

        void AddLeftButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User();
            newUser.Width = 100;
            newUser.Height = 100;
            newUser.Margin = new Thickness(15, 15, 15, 15);
            newUser.ImageSource = "/Resources/Images/user_friend.png";
            newUser.UserName = "Prijatelj";
            newUser.Delete += OnUserDelete;

            this.LeftContainer.Children.Add(newUser);
        }

        void AddRightButton_Click(object sender, RoutedEventArgs e)
        {
            var newPost = new Post();
            newPost.Margin = new Thickness(35, 15, 35, 15);
            newPost.Background = Brushes.PowderBlue;
            newPost.PostText = "This is a post. :)";
            newPost.Delete += OnPostDelete;

            this.RightContainer.Children.Add(newPost);
        }
    }
}
