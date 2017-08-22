using System;
using System.Windows;

namespace Password_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region private members

        Random rnd = new Random();

        private char returnedChar;

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

        /// <summary>
        /// Describes what happens when a user change the slider value 
        /// </summary>
        /// <param name="sender">The Main Slider</param>
        /// <param name="e">Value</param>
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            // change text to the following
            if (Slide.Value < 8)
                Difficulty.Text = "Password can't be less than 8 letters";

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

        /// <summary>
        /// Creates a password
        /// </summary>
        /// <param name="value">The value of how long the password should be</param>
        private void createPassword(int value)
        {
            // the program will ignore the code if the value is 8
            if (value < 8)
                return;

            // Clears the password place
            passwordPlace.Text = string.Empty;

            // Loops till the end and randomly choose the char according to which checkboxes the user chose
            for (int counter = 0; counter < value;)
            {

                // Checks if the capital letters checkbox is checked
                if (cLetters.IsChecked == true)
                {
                    counter++;
                    passwordPlace.Text += generateRandomCharacters(65, 90);

                    if (counter >= value)
                        break;
                }

                // Checks if the small letters checkbox is checked
                if (sLetters.IsChecked == true)
                {
                    counter++;
                    passwordPlace.Text += generateRandomCharacters(97, 122);

                    if (counter >= value)
                        break;
                }

                // Checks if the numbers checkbox is checked
                if (numbers.IsChecked == true)
                {
                    counter++;
                    passwordPlace.Text += generateRandomCharacters(48, 57);

                    if (counter >= value)
                        break;
                }

                // Checks if the symbols checkbox is checked
                if (symbols.IsChecked == true)
                {
                    counter++;
                    passwordPlace.Text += generateRandomCharacters(33, 47);

                    if (counter >= value)
                        break;
                }

            }
        }

        /// <summary>
        /// Random choose a random char
        /// </summary>
        /// <param name="start">Starting point for ascii code</param>
        /// <param name="end">Ending point for ascii code</param>
        /// <returns>The random chosen char</returns>
        private char generateRandomCharacters(int start, int end)
        {
            // returns the char according to this formula
            return returnedChar = (char)rnd.Next(start, end);
        }

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

    }
}
