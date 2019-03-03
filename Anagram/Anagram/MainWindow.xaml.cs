using System;
using System.Collections.Generic;
using System.Windows;

namespace Anagram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            
            if(isAnagram(txtBx_Input1.Text, txtBx_Input2.Text)){
                string result = "The two phrases are an Anagram!";
                txtBx_Result.Text = result;
            }
            else
            {
                string result = "The two phrases are NOT an Anagram!";
                txtBx_Result.Text = result;
            }
        }

        private bool isAnagram(string firstPhrase, string secondPhrase)
        {
            //Return true if the first phrase is equal to the second phrase
            if (firstPhrase.Equals(secondPhrase))
            {
                return true;
            }

            //If the phrases have different lengths, then they cannot be anagrams. Return false.
            if (firstPhrase.Length != secondPhrase.Length)
            {
                return false;
            }

            //Set the phrases to lower case.
            firstPhrase = firstPhrase.ToLower();
            secondPhrase = secondPhrase.ToLower();

            //Create a dictionary with a char as the Key, and an int as they value.
            Dictionary<char, int> firstPhraseDictionary = new Dictionary<char, int>();

            //Iterate through each character in the first phrase.
            //Look through the dictionary looking for the char value of the key.
            //If the char value does not exist, add the element.
            //If the char value does exist, increment the int value in the dictionary.
            foreach (char c in firstPhrase.ToCharArray())
            {
                if (firstPhraseDictionary.ContainsKey(c))
                {
                    firstPhraseDictionary[c]++;
                }
                else
                {
                    firstPhraseDictionary.Add(c, 1);
                }
            }

            //Iterate through each character in the second phrase.
            //If the firstPhraseDictionary does not contain the char key value, return false.
            //If the firstPhraseDictionary does contain the char key value, subract one from that value.
            //If the int value is <= zero, remove the dictionary value from firstPhraseDictionary.
            foreach (char c in secondPhrase.ToCharArray())
            {
                if (!firstPhraseDictionary.ContainsKey(c))
                {
                    return false;
                }
                if (firstPhraseDictionary.ContainsKey(c))
                {
                    firstPhraseDictionary[c]--;
                    if (firstPhraseDictionary[c] <= 0)
                    {
                        firstPhraseDictionary.Remove(c);
                    }
                }
            }

            //Look at the count of the firstPhraseDictionary. If the count equals zero, then it is an anagram.
            if (firstPhraseDictionary.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
