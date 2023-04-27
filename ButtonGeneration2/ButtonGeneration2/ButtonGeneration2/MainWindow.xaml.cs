using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.IO;
namespace ButtonGeneration2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 10;
        private int index = 0;  
        List<string> Strings = new List<string>();
      
        public MainWindow()
        {
            InitializeComponent();

            var MyList = new List<string>();
            using (var streamReader = File.OpenText("C:\\Users\\admin\\Desktop\\Book.txt"))               
            {
                int v = MyList.Count;   
                for (int i = v; i <= 76; i++)
                {
                    var s = string.Empty;
                    int length = s.Length;                  
                    while ((s = streamReader.ReadLine()) != null)
                        Strings.Add(s);

            }   }
            lbTest.ItemsSource = MyList;
           
            lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
            ButtonGeneration();       
        }

        public void ButtonGeneration()
        {
           for(int i = 0;i < MaxIndex(); i++)
            {
                var a = new Button();
                a.Name = "bt" + i.ToString();
                a.Content = (i + 1).ToString();  
                a.Margin = new Thickness(5); 
                a.Padding = new Thickness(5);
                a.Click += btnDown_Click;

                if(i == 0) 
                { 
                    a.Background = new SolidColorBrush(Colors.BlueViolet);   
                }
                spButton.Children.Add(a);   
            }
        }

        private int MaxIndex()
        {
            decimal a = (decimal)Strings.Count / (decimal)count;
            int max = (int)Math.Ceiling(a);
            return max;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            var a =(Button)sender;
            switch(a.Name)
            {
                case "btnDown": DownContent();
                    break;
                case "btnUP": UpContent();
                    break;
                default: BtnGo(a);
                    break; 
            }


        }

        private void BtnGo(Button a)
        {
            RefrashColor();

            a.Background = Brushes.BlueViolet;
            index = Convert.ToInt32(a.Content) - 1;
            lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
        }

        private void UpContent()
        {
            int max = MaxIndex();   

            if(index < max - 1)
            {
                index++;
                lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
                NextColorButton();  
            }
        }

        private void DownContent()
        {
           if(index > 0)
            {
                index--;
                lbTest.ItemsSource = Strings.Skip(index * count).Take(count);
                NextColorButton();
            }
        }

        private void NextColorButton()
        {
            RefrashColor();
            foreach(var item in spButton.Children)
            {
                var a = item as Button; 
                if(a.Content == (index + 1).ToString())    
                {
                    a.Background = Brushes.Red;
                }
            }
        }

        private void RefrashColor()
        {
            foreach(var item in spButton.Children)  
            {
                var a = item as Button;
                a.Background = Brushes.White;
            }
        }       
    }
}
