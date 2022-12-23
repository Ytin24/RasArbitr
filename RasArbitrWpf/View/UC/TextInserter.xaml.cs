using RasArbitrWPF.View.UC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RasArbitrWPF.UC {
    /// <summary>
    /// Логика взаимодействия для TextInserter.xaml
    /// </summary>
    public partial class TextInserter : UserControl, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public TextInserter() {
            InitializeComponent();
            this.DataContext = this;
            Items = new();
            AddFirstInForm();
        }
        private ObservableCollection<StackPanel> _Items;
        public ObservableCollection<StackPanel> Items {
            get {
                return this._Items;
            }

            set {
                this._Items = value;
                NotifyPropertyChanged();
            }
        }
        public List<string> ItemText = new();
        private void AddFirstInForm() {

            var NewItem = new StackPanel() {
                Orientation = Orientation.Horizontal,
            };
            var ButtonAddOrRemove = new Button() {
                Content = new Image() {
                    Source = GetImage.doGetImageSourceFromResource(Assembly.GetExecutingAssembly().FullName, "View/Assets/plus.png"),
                    Height = 20,
                    Width = 20,
                },
                Background = (Brush)new BrushConverter().ConvertFromString(Color.FromRgb(219,184,4).ToString()),
                Padding = new Thickness(0),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderThickness = new Thickness(0),
            };
            ButtonAddOrRemove.Click += ButtonAddOrRemove_Click;

            var ItemTextBox = new TextBox() {
                Width = 230,
                Height = 20,
            };
            ItemTextBox.TextChanged += TbTextInput;
            NewItem.Children.Add(ItemTextBox);
            NewItem.Children.Add(new Separator() { Opacity = 0, Width = 3 });
            NewItem.Children.Add(ButtonAddOrRemove);
            Items.Add(NewItem);
            ItemText.Add("");
            RootUC.Children.Add(NewItem);
        }
        private void ButtonAddOrRemove_Click(object sender, RoutedEventArgs e) {
            AddNewInForm();
        }

        private void AddNewInForm() {

            var NewItem = new StackPanel() {
                Orientation = Orientation.Horizontal,
            };
            var ButtonAddOrRemove = new Button {
                Content = new Image() {
                    Source = GetImage.doGetImageSourceFromResource(Assembly.GetExecutingAssembly().FullName, "View/Assets/minus.png"),
                    Height = 20,
                    Width = 20,

                },
                Background = (Brush)new BrushConverter().ConvertFromString(Color.FromRgb(219, 184, 4).ToString()),
                Padding = new Thickness(0),
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                BorderThickness = new Thickness(0),
                Tag = NewItem.GetHashCode()
            };
            ButtonAddOrRemove.Click += RemoveItem;

            var ItemTextBox = new TextBox() {
                Width = 190,
                Height = 20,
            };
            ItemTextBox.TextChanged += TbTextInput;
            NewItem.Children.Add(ItemTextBox);
            NewItem.Children.Add(new Separator() { Opacity = 0, Width = 3 });
            NewItem.Children.Add(ButtonAddOrRemove);
            ButtonAddOrRemove.Tag = NewItem.GetHashCode();
            Items.Add(NewItem);
            ItemText.Add("");
            RootUC.Children.Add(NewItem);
        }

        private void RemoveItem(object sender, RoutedEventArgs e) {
            var btn = sender as Button;
            int Hash = (int)btn.Tag;
            var panelI = Items.IndexOf(Items.First(x => x.GetHashCode() == Hash));
            var panel = Items[panelI];
            Items.Remove(panel);
            RootUC.Children.Remove(panel);
            ItemText.RemoveAt(panelI);
        }

        private void TbTextInput(object sender, RoutedEventArgs eventArgs) {
            var panel = Items.First(x => x.Children.Contains(sender as TextBox));
            var index = Items.IndexOf(panel);
            ItemText[index] = (sender as TextBox).Text;
        }
    }
}
