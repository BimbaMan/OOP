using System;
using System.Collections.Generic;
using System.Windows.Forms;
using laba3.models;
using laba3.services.serialization;

namespace laba3
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Animal> dictionary;
        private List<Animal> listOfPets;
        private ISerialization textSerialization;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textSerialization = new TextSerializator();
            listOfPets = new List<Animal>();
            dictionary = new Dictionary<string, Animal>()
            {
                {"Cat", new Cat()},
                {"Dog", new Dog()},
            };
            foreach(var item in dictionary.Keys)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void buttonSerialize_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            string result = textSerialization.Serialize(listOfPets);
            System.IO.File.WriteAllText(filename, result);
        }

        private void buttonDeserialize_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            listOfPets.AddRange(textSerialization.Deserialize(fileText));
            listBox1.Items.Clear();
            ListShow();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Type type = dictionary.GetValueOrDefault(comboBox1.Text).GetType();
            Animal pet = (Animal)Activator.CreateInstance(type);
            pet.Name = textBoxName.Text;
            pet.Age = Convert.ToInt16(textBoxAge.Text);
            pet.Weight = Convert.ToInt16(textBoxColor.Text);
            listOfPets.Add(pet);
            listBox1.Items.Add($"Type: {comboBox1.Text}, Name: {textBoxName.Text}, Age: {textBoxAge.Text}, Weight: {textBoxColor.Text}");
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(index);
            listOfPets.RemoveAt(index);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            listOfPets[index].Name = textBoxName.Text;
            listOfPets[index].Age = Convert.ToInt16(textBoxAge.Text);
            listOfPets[index].Weight = Convert.ToInt16(textBoxColor.Text);
            listBox1.Items.Insert(index+1, $"Type: {comboBox1.Text}, Name: {textBoxName.Text}, Age: {textBoxAge.Text}, Weight: {textBoxColor.Text}");
            listBox1.Items.RemoveAt(index);
        }

        private void Clear()
        {
            textBoxAge.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxColor.Text = string.Empty;
            comboBox1.Text = string.Empty;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if(index != -1)
            {
                string str = listBox1.SelectedItem.ToString();
                string[] strArray = str.Split(',');
                comboBox1.Text = strArray[0].Substring(strArray[0].IndexOf("Type: ")+6);
                textBoxName.Text = strArray[1].Substring(strArray[1].IndexOf("Name: ")+6);
                textBoxAge.Text = strArray[2].Substring(strArray[2].IndexOf("Age: ")+5);
                textBoxColor.Text = strArray[3].Substring(strArray[3].IndexOf("Weight: ")+7);
            }
        }

        private void ListShow()
        {
            foreach(var item in listOfPets)
            {
                listBox1.Items.Add($"Type: {item.GetType().Name}, Name: {item.Name}, Age: {item.Age}, Weight: {item.Weight}");
            }
        }
    }
}
