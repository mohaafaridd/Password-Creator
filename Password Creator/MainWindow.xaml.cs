using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace Password_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private members

        private Random rnd = new Random();

        private List<int> availableCharacters = new List<int>();

        #endregion

        #region Default Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Slide

        /// <summary>
        /// Describes what happens when a user change the slider value 
        /// </summary>
        /// <param name="sender">The Main Slider</param>
        /// <param name="e">Value</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            // change text to the following
            if (Slide.Value < 8)
                Difficulty.Text = "Too easy";

            // Sets the difficulty to Easy
            if (Slide.Value > 8)
                Difficulty.Text = "Easy";

            // Sets the difficulty to Medium
            if (Slide.Value > 16)
                Difficulty.Text = "Medium";

            // Sets the difficulty to Hard
            if (Slide.Value > 32)
                Difficulty.Text = "Hard";

            // Sets the difficulty to Really Hard
            if (Slide.Value > 64)
                Difficulty.Text = "Really Hard";

            // Tells how many char user password will contain
            number.Text = Slide.Value.ToString();

            // creates a password according to the chosen check boxes
            createPassword((int)Slide.Value);
        }

        #endregion

        #region Password Creators
        /// <summary>
        /// Creates a password
        /// </summary>
        /// <param name="value">password length</param>
        private void createPassword(int value)
        {
            // Deletes any former password
            passwordPlace.Text = string.Empty;

            // Add the selected boxes and their values to the list
            addIndexes(ref availableCharacters);

            // Escape if the list is empty
            if (availableCharacters.Count == 0)
                return;

            // Go to the generator
            generatePassword(availableCharacters, value);
        }

        /// <summary>
        /// Generates the password from the given values
        /// </summary>
        /// <param name="availableCharacters"></param>
        /// <param name="value"></param>
        private void generatePassword(List<int> availableCharacters, int value)
        {
            // Loop through the needed length
            for(int i = 0; i< value; i++)
            {
                // Creating random index to search in the list with
                int index = rnd.Next(availableCharacters.Count);

                // Adding the chosen character to the textbox - Cast number to ASCII
                passwordPlace.Text += (char)availableCharacters[index];

            }
        }

        /// <summary>
        /// Adding elements to the list depending on the checked boxes
        /// </summary>
        /// <param name="availableCharacters"></param>
        private void addIndexes(ref List<int> availableCharacters)
        {
            // Clear the list from any element
            availableCharacters.Clear();

            // Adding ASCII for captial letters
            if (cLetters.IsChecked == true)
            {
                for (int ASCIINumber = 65; ASCIINumber < 91; ASCIINumber++)
                    availableCharacters.Add(ASCIINumber);
            }

            // Adding ASCII for small letters
            if (sLetters.IsChecked == true)
            {
                for (int ASCIINumber = 97; ASCIINumber < 123; ASCIINumber++)
                    availableCharacters.Add(ASCIINumber);
            }

            // Adding ASCII for number (0-9)
            if (numbers.IsChecked == true)
            {
                for (int ASCIINumber = 48; ASCIINumber < 58; ASCIINumber++)
                    availableCharacters.Add(ASCIINumber);
            }

            // Adding ASCII for symbols
            if (symbols.IsChecked == true)
            {
                for (int ASCIINumber = 33; ASCIINumber < 48; ASCIINumber++)
                    availableCharacters.Add(ASCIINumber);
            }


            availableCharacters.Sort();
        }
        #endregion

        #region Helping Buttons
        /// <summary>
        /// Creates new password with the same number of char if the user wanted that
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            // call the same method and do a new password
            createPassword((int)Slide.Value);
        }

        /// <summary>
        /// Copy the password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copier_Click(object sender, RoutedEventArgs e)
        {
            // Copy the password
            Clipboard.SetText(passwordPlace.Text);
        }
        #endregion

        #region Mouse Visual Effects
        /// <summary>
        /// Change the color of text when mouse enter the area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordPlace_MouseEnter(object sender, MouseEventArgs e)
        {
            // Change color to Orange
            passwordPlace.Foreground = Brushes.Orange;
        }

        /// <summary>
        /// Change the color of text when mouse leave the area
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordPlace_MouseLeave(object sender, MouseEventArgs e)
        {
            // Change color to Black
            passwordPlace.Foreground = Brushes.Black;

        }
        #endregion
    }
}
