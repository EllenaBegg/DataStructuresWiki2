using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

/*
 * Name/ID: Ellena Begg, 30040389
 * Date: 1 June 2022
 * Version 1.2 Final
 * Program Name: Data Structures Wiki 2
 * Description: C# Assessment Task 2
 *              A small Wiki for Data Structure types.
 *              A uniform definition and cataloguing of this information.
 *              Users can add and delete from the Wiki, and edit items. 
 *              Users can open from and save to a Binary file.
 */

namespace DataStructuresWiki2
{
    public partial class WikiForm : Form
    {
        public WikiForm()
        {
            InitializeComponent();
        }

        #region StaticVariables

        // 6.2 Create a global List<T> of type Information called Wiki.
        static List<Information> Wiki = new List<Information>();
        // 6.4 Create a global String array with the six Categories
        static string[] categories;
        //static string testOutput = ""; // for testing output


        #endregion

        #region Utilities

        // 6.9 Create a single custom method that will sort and then display the Name and Category from the Wiki information in the list.
        /// <summary>
        /// Display all items in the Wiki to the screen.
        /// </summary>
        private void DisplayWiki()
        {
            if (Wiki.Count > 0)
            {
                Wiki.Sort();
                listViewWiki.Items.Clear();
                foreach (var information in Wiki)
                {
                    ListViewItem lvi = new ListViewItem(information.GetName());
                    lvi.SubItems.Add(information.GetCategory());
                    listViewWiki.Items.Add(lvi);
                }
            }
        }

        /// <summary>
        /// Save the contents of the List<Information> to a Binary file.
        /// </summary>
        /// <param name="fileName">The name to save the file as</param>
        private void SaveBinaryFile(string fileName)
        {
            try
            {
                using (var stream = File.Open(fileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        foreach (var info in Wiki)
                        {
                            writer.Write(info.GetName());
                            writer.Write(info.GetCategory());
                            writer.Write(info.GetStructure());
                            writer.Write(info.GetDefinition());
                        }
                    }
                }
                toolStripStatusLabel1.Text = "File Saved.";
            }
            catch (IOException ex)
            {
                MessageBox.Show("File could not be saved.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Open a Binary file and write contents to the List<Information>.
        /// </summary>
        /// <param name="fileName">The name of the file to open</param>
        //private void OpenBinaryFile(string fileName)
        //{
        //    try
        //    {
        //        using (var stream = File.Open(fileName, FileMode.Open))
        //        {
        //            using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
        //            {
        //                Wiki.Clear();
        //                while (stream.Position < reader.BaseStream.Length)
        //                {
        //                    Information info = new Information();
        //                    info.SetName(reader.ReadString());
        //                    info.SetCategory(reader.ReadString());
        //                    info.SetStructure(reader.ReadString());
        //                    info.SetDefintion(reader.ReadString());
        //                    Wiki.Add(info);
        //                }
        //            }
        //        }
        //        DisplayWiki();
        //    }
        //    catch (IOException ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //        MessageBox.Show("File could not be opened.\n" + ex.Message);
        //    }
        //}
        private bool OpenBinaryFile(string fileName)
        {
            bool fileHasContents = false;
            try
            {
                using (var stream = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        Wiki.Clear();
                        while (stream.Position < reader.BaseStream.Length)
                        {
                            Information info = new Information();
                            info.SetName(reader.ReadString());
                            info.SetCategory(reader.ReadString());
                            info.SetStructure(reader.ReadString());
                            info.SetDefintion(reader.ReadString());
                            Wiki.Add(info);
                        }
                        if (Wiki.Count > 0)
                        {
                            fileHasContents = true;
                            buttonSave.Enabled = true;
                        }
                    }
                }
                DisplayWiki();
            }
            catch (IOException ex)
            {
                MessageBox.Show("File could not be opened.\n" + ex.Message);
            }
            return fileHasContents;
        }

        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name
        // and returns a Boolean after checking for duplicates.
        // Use the built in List<T> method “Exists” to answer this requirement.
        /// <summary>
        /// Check that the new Name does not already exist in the Wiki.
        /// </summary>
        /// <param name="checkName">The new name to check</param>
        /// <returns>true when the new Name doesn't already exist, false if the new Name already exists.</returns>
        private bool IsValidName(string checkName)
        {
            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.WriteLine("IsValidName called. checkName value: " + checkName);
            //testOutput += "IsValidName called. checkName value: " + checkName + "\n";
            //Trace.WriteLine("checkName value: " + checkName);
            //testOutput += "checkName value: " + checkName + "\n";

            if (Wiki.Exists(dup => dup.GetName() == checkName))
            {
                //Trace.WriteLine(checkName + " is a duplicate, so it's NOT VALID.");
                //testOutput += checkName + " is a duplicate, so it's NOT VALID.\n";

                toolStripStatusLabel1.Text = "That name already exists.";

                return false; //not valid, as already exists
            }
            else
            {
                //Trace.WriteLine(checkName + " is VALID.");
                //testOutput += checkName + " is VALID.\n";

                return true; //is valid, it is a NEW name
            }
        }

        // 6.4 Create and initialise a global string array with the six categories as indicated in the Data Structure Matrix.
        /// <summary>
        /// Read from the Categories text file into the global string[].
        /// If the text file is not present, create it, then read from it.
        /// </summary>
        private void ReadCategoriesFromFile()
        {
            string categoriesFileNameIncludingPath = Path.Combine(Application.StartupPath, "Categories.txt");
            if (File.Exists(categoriesFileNameIncludingPath))
            {
                try
                {
                    using (var streamReader = new StreamReader(categoriesFileNameIncludingPath))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            int categoriesCount = File.ReadLines(categoriesFileNameIncludingPath).Count();
                            categories = new string[categoriesCount];

                            for (int x = 0; x < categoriesCount; x++)
                            {
                                categories[x] = streamReader.ReadLine();
                            }
                        }
                    }
                }
                catch (IOException exc)
                {
                    MessageBox.Show("ReadCategoriesFromFile exc: " + exc.Message);
                }
            }
            else
            {
                CreateCategoriesTextFile();
                ReadCategoriesFromFile();
            }

        }

        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called.
        /// <summary>
        /// Fill the ComboBox with all available Categories.
        /// </summary>
        private void FillComboBoxCategories()
        {
            foreach (string category in categories)
            {
                comboBoxCategory.Items.Add(category);
            }
        }

        /// <summary>
        /// Clear the Name and Definition text boxes, and unselect any items in the Category combobox and Structure radio buttons,
        /// and unselect any items in the list view.
        /// </summary>
        private void ClearTextBoxes()
        {
            textBoxName.Clear();
            textBoxDefinition.Clear();
            comboBoxCategory.SelectedIndex = -1;
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            listViewWiki.SelectedItems.Clear(); // make sure no item selected in ListView
        }

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The first method must return a string value from the selected radio button (Linear or Non-Linear).
        /// <summary>
        /// Check the appropriate radio button for the Structure of the selected Information object.
        /// </summary>
        /// <param name="index">The index of the selected Information object in the Wiki List</param>
        private void SetStructureForExisting(int index)
        {
            string structure = Wiki[index].GetStructure();
            if (structure == "Linear")
            {
                radioButtonLinear.Checked = true;
                radioButtonNonLinear.Checked = false;//need?
            }
            else
            {
                radioButtonNonLinear.Checked = true;
                radioButtonLinear.Checked = false;//need?
            }
        }

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The second method must send an integer index which will highlight an appropriate radio button.
        /// <summary>
        /// Set the Structure for this Information object with the radio button that is checked.
        /// We have already checked that one of the radio buttons is actually checked before calling this method.
        /// </summary>
        /// <returns>Either "Linear" or "Non-Linear".</returns>
        private string SetStructureForNew()
        {
            if (radioButtonLinear.Checked)
                return radioButtonLinear.Text;
            else
                return radioButtonNonLinear.Text;
        }

        /// <summary>
        /// Checks that the Name and Definition text boxes have data, that a Category is selected, and
        /// that a Structure is selected.
        /// </summary>
        /// <returns>true when there is data in all input fields, false when at least one of the input fields is empty or not selected.</returns>
        private bool AllValuesPresent()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                toolStripStatusLabel1.Text = "Name can not be empty.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                toolStripStatusLabel1.Text = "Definition can not be empty.";
                return false;
            }
            if (comboBoxCategory.SelectedIndex < 0)
            {
                toolStripStatusLabel1.Text = "Select a Category.";
                return false;
            }
            if ((!radioButtonLinear.Checked) && (!radioButtonNonLinear.Checked))
            {
                toolStripStatusLabel1.Text = "Select a Structure type.";
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Creates a text file containing 6 different Categories. File is written to the current application startup directory.
        /// </summary>
        private void CreateCategoriesTextFile()
        {
            // Valid Categories
            string[] validCategories = new string[] { "Array", "List", "Tree", "Graph", "Abstract", "Hash" };

            try
            {
                using (var streamWriter = new StreamWriter(Path.Combine(Application.StartupPath, "Categories.txt")))
                {
                    foreach (string category in validCategories)
                    {
                        streamWriter.WriteLine(category);
                    }
                }
            }
            catch (IOException exc)
            {
                MessageBox.Show("CreateCategoriesTextFile exc: " + exc.Message);
            }
        }

        /// <summary>
        /// Creates a Wiki based on the original data of Data Structures supplied.
        /// </summary>
        private void CreateOriginalWiki()
        {
            // create each D.S., then add to List<T>
            Information information = new Information();
            information.SetName("Array");
            information.SetCategory("Array");
            information.SetStructure("Linear");
            information.SetDefintion("An array data structure consists of a collection of elements (values or variables), each identified by at least one array index or key. An array is stored such that the position of each element can be computed from its index tuple by a mathematical formula.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Two Dimension Array");
            information.SetCategory("Array");
            information.SetStructure("Linear");
            information.SetDefintion("A two-dimensional array can be visualised as a grid (or table) with rows and columns. Positions in a two dimensional array are referenced like a map using horizontal and vertical reference numbers. They are sometimes called matrices.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("List");
            information.SetCategory("List");
            information.SetStructure("Linear");
            information.SetDefintion("A list or sequence is an abstract data type that represents a finite number of ordered values, where the same value may occur more than once.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Linked list");
            information.SetCategory("List");
            information.SetStructure("Linear");
            information.SetDefintion("A linked list is a linear collection of data elements whose order is not given by their physical placement in memory. Instead, each element points to the next. It is a data structure consisting of a collection of nodes which together represent a sequence.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Self-Balance Tree");
            information.SetCategory("Tree");
            information.SetStructure("Non-Linear");
            information.SetDefintion("A self-balancing tree is any node-based binary search tree that automatically keeps its height (maximal number of levels below the root) small in the face of arbitrary item insertions and deletions.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Heap");
            information.SetCategory("Tree");
            information.SetStructure("Non-Linear");
            information.SetDefintion("A heap is a specialized tree-based data structure which is essentially an almost complete tree that satisfies the heap property. The heap is one maximally efficient implementation of an abstract data type called a priority queue, priority queues are often referred to as \"heaps\")");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Binary Search Tree");
            information.SetCategory("Tree");
            information.SetStructure("Non-Linear");
            information.SetDefintion("A binary search tree (BST), also called an ordered or sorted binary tree, is a rooted binary tree data structure whose internal nodes each store a key greater than all the keys in the node’s left subtree and less than those in its right subtree.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Graph");
            information.SetCategory("Graphs");
            information.SetStructure("Non-Linear");
            information.SetDefintion("A graph data structure consists of a finite set of vertices, together with a set of unordered pairs of these vertices for an undirected graph or a set of ordered pairs for a directed graph to implement the undirected graph and directed graph concepts from the field of graph theory within mathematics.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Set");
            information.SetCategory("Abstract");
            information.SetStructure("Non-Linear");
            information.SetDefintion("A set is an abstract data type that can store unique values, without any particular order. It is a computer implementation of the mathematical concept of a finite set. Unlike most other collection types, rather than retrieving a specific element from a set, one typically tests a value for membership in a set.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Queue");
            information.SetCategory("Abstract");
            information.SetStructure("Linear");
            information.SetDefintion("A queue is a collection of entities that are maintained in a sequence and can be modified by the addition of entities at one end of the sequence and the removal of entities from the other end of the sequence.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Stack");
            information.SetCategory("Abstract");
            information.SetStructure("Linear");
            information.SetDefintion("A stack is an abstract data type that serves as a collection of elements, with two main principal operations: Push, which adds an element to the collection, and Pop, which removes the most recently added element that was not yet removed.");
            Wiki.Add(information);

            information = new Information();
            information.SetName("Hash Table");
            information.SetCategory("Hash");
            information.SetStructure("Non-Linear");
            information.SetDefintion("A hash table is a data structure that implements an associative array abstract data type, a structure that can map keys to values. A hash table uses a hash function to compute an index, also called a hash code, into an array of buckets or slots, from which the desired value can be found.");
            Wiki.Add(information);
        }

        #endregion

        #region TESTING
        // TESTING
        //private void SaveOutputFile()
        //{
        //    try
        //    {
        //        using (var streamWriter = new StreamWriter(Path.Combine(Application.StartupPath, "TestOutputData.txt")))
        //        {
                    
        //            streamWriter.WriteLine(testOutput);
        //        }
        //    }
        //    catch (IOException exc)
        //    {
        //        MessageBox.Show("SaveOutputFile exc: " + exc.Message);
        //    }
        //}

        // TESTING
        //private void SaveOutputFile(string data)
        //{
        //    try
        //    {
        //        using (var streamWriter = new StreamWriter(Path.Combine(Application.StartupPath, "TestOutputDataFromClass.txt")))
        //        {

        //            streamWriter.WriteLine(data);
        //        }
        //    }
        //    catch (IOException exc)
        //    {
        //        MessageBox.Show("SaveOutputFile exc: " + exc.Message);
        //    }
        //}

        #endregion

        #region ButtonClickEvents
        // 6.3 Create a button method to ADD a new item to the list.
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (AllValuesPresent())
            {
                // confirm Add with dialog
                DialogResult dr = MessageBox.Show("Do you want to Add this Data Structure?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (IsValidName(textBoxName.Text))
                    {
                        Information newInformation = new Information();
                        newInformation.SetName(textBoxName.Text);
                        newInformation.SetDefintion(textBoxDefinition.Text);
                        newInformation.SetStructure(SetStructureForNew());
                        newInformation.SetCategory(comboBoxCategory.Text);
                        Wiki.Add(newInformation);

                        DisplayWiki();
                        ClearTextBoxes();
                        toolStripStatusLabel1.Text = "Item successfully added.";
                    } 
                    else
                    {
                        return; // when there is a duplicate. No duplicates permitted.
                    }
                } 
                else
                {
                    toolStripStatusLabel1.Text = "Add cancelled.";
                }
            }
        }

        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView.
        // All the changes in the input controls will be written back to the list.
        // Display an updated version of the sorted list at the end of this process.
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.WriteLine("Edit Click: ");
            //testOutput += "Edit Click: \n";

            if (AllValuesPresent())
            {
                // confirm Edit with dialog
                DialogResult dr = MessageBox.Show("Do you want to Edit this Data Structure?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (IsValidName(textBoxName.Text))
                    {
                        int currentRecord = listViewWiki.SelectedIndices[0];

                        //Trace.WriteLine("Edit. Old Values: " + Wiki[currentRecord].GetName() + ", " + Wiki[currentRecord].GetCategory() + ", " + Wiki[currentRecord].GetStructure() + ", " + Wiki[currentRecord].GetDefinition());
                        //testOutput += "Edit. Old Values: " + Wiki[currentRecord].GetName() + ", " + Wiki[currentRecord].GetCategory() + ", " + Wiki[currentRecord].GetStructure() + ", " + Wiki[currentRecord].GetDefinition() + "\n";

                        Wiki[currentRecord].SetName(textBoxName.Text);
                        Wiki[currentRecord].SetDefintion(textBoxDefinition.Text);
                        Wiki[currentRecord].SetCategory(comboBoxCategory.Text);
                        Wiki[currentRecord].SetStructure(SetStructureForNew());

                        //Trace.WriteLine("Edit. New Values: " + Wiki[currentRecord].GetName() + ", " + Wiki[currentRecord].GetCategory() + ", " + Wiki[currentRecord].GetStructure() + ", " + Wiki[currentRecord].GetDefinition());
                        //testOutput += "Edit. New Values: " + Wiki[currentRecord].GetName() + ", " + Wiki[currentRecord].GetCategory() + ", " + Wiki[currentRecord].GetStructure() + ", " + Wiki[currentRecord].GetDefinition() + "\n";

                        DisplayWiki();
                        ClearTextBoxes();
                        toolStripStatusLabel1.Text = "Item successfully edited.";
                    }
                    else
                    {
                        //Trace.WriteLine("Edit. Invalid Name detected:" + textBoxName.Text);
                        //testOutput += "Edit. Invalid Name detected:" + textBoxName.Text + "\n";

                        return; // when there is a duplicate. No duplicates permitted.
                    }
                } 
                else
                {
                    //Trace.WriteLine("Edit. Cancelled");
                    //testOutput += "Edit. Cancelled\n";

                    toolStripStatusLabel1.Text = "Edit cancelled.";
                }
            }
            //Trace.WriteLine("Edit. AllValuesPresent method returned FALSE. Something is missing.");
            //testOutput += "Edit. AllValuesPresent method returned FALSE. Something is missing.\n";
        }

        // 6.7 Create a button method that will delete the currently selected record in the ListView.
        // Ensure the user has the option to backout of this action by using a dialog box.
        // Display an updated version of the sorted list at the end of this process.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.WriteLine("Delete Click: ");
            //testOutput += "Delete Click: \n";

            if (listViewWiki.SelectedItems.Count > 0)
            {
                // confirm Delete with dialog
                DialogResult dr = MessageBox.Show("Do you want to delete this Data Structure?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int index = listViewWiki.SelectedIndices[0];

                    string oldName = Wiki[index].GetName();

                    //Trace.WriteLine("Delete. Number of Objects in List: " + Wiki.Count.ToString());
                    //testOutput += "Delete. Number of Objects in List: " + Wiki.Count.ToString() + "\n";
                    //Trace.WriteLine("Delete. " + oldName + " about to be deleted.");
                    //testOutput += "Delete. " + oldName + " about to be deleted.\n";

                    Wiki.RemoveAt(index);

                    //Trace.WriteLine("Delete. Number of Objects in List: " + Wiki.Count.ToString());
                    //testOutput += "Delete. Number of Objects in List: " + Wiki.Count.ToString() + "\n";

                    DisplayWiki();

                    toolStripStatusLabel1.Text = oldName + " successfully deleted.";
                }
                else
                {
                    //Trace.WriteLine("Delete. Cancelled");
                    //testOutput += "Delete. Cancelled\n";

                    toolStripStatusLabel1.Text = "Delete cancelled.";
                }
            }
            else
            {
                //Trace.WriteLine("Delete. No D.S. selected in ListView.");
                //testOutput += "Delete. No D.S. selected in ListView.\n";

                toolStripStatusLabel1.Text = "NOTE: No Data Structure selected to Delete. Select a Data Structure first.";
                return;
            }
            ClearTextBoxes();
        } // end buttonDelete_Click()

        // 6.14 Create button for the manual open option;
        // This must use a dialog box to select a file or rename a saved file.
        // All Wiki data is stored/retrieved using a binary file format.
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            //use dialog box
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Binary File | *.bin";
            openFileDialog.Title = "Select a Binary File";

            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;

            if (dr == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                _ = OpenBinaryFile(fileName);
                buttonSave.Enabled = true;
            }
        } // end buttonOpen_Click()

        // 6.14 Create button for the manual save option;
        // This must use a dialog box to select a file or rename a saved file.
        // All Wiki data is stored/retrieved using a binary file format.
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //use dialog box
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "Binary File | *.bin";

            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;

            if (dr == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                SaveBinaryFile(fileName);
            }

        } // end buttonSave_Click()

        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls
        // and highlight the name in the ListView.
        // At the end of the search process the search input TextBox must be cleared.
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            if(!string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                Information information = new Information();
                information.SetName(textBoxSearch.Text);
                int found = Wiki.BinarySearch(information); //use the builtin binary search to find a Data Structure name

                //TESTING
                //testOutput += "\nSEARCH\n\tObject Name value: " + textBoxSearch.Text + "\n\tReturned index value of BinarySearch method: " + found.ToString() + "\n";

                if (found >= 0)
                {
                    listViewWiki.SelectedItems.Clear();
                    listViewWiki.Items[found].Selected = true; //highlight the name in the ListView
                    listViewWiki.Focus();

                    //If the record is found the associated details will populate the appropriate input controls
                    textBoxName.Text = Wiki[found].GetName();
                    comboBoxCategory.Text = Wiki[found].GetCategory();
                    SetStructureForExisting(found);
                    textBoxDefinition.Text = Wiki[found].GetDefinition();
                }
                else
                {
                    toolStripStatusLabel1.Text = information.GetName() + " not found.";
                }
            }
            textBoxSearch.Clear();
        }

        // 6.12 Create a custom method that will clear and reset the TextBboxes, ComboBox and Radio button
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        #endregion

        #region Form, ListView and TextBox events

        // 6.15 The Wiki application will save data when the form closes. 
        private void WikiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveBinaryFile("Wiki.bin");

            // Testing
            //SaveOutputFile();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        private void textBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearTextBoxes();
        }

        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names
        // and the associated information will be displayed in the related text boxes combo box and radio button.
        private void listViewWiki_MouseClick(object sender, MouseEventArgs e)
        {
            int currentRecordIndex = listViewWiki.SelectedIndices[0];
            textBoxName.Text = Wiki[currentRecordIndex].GetName();
            comboBoxCategory.Text= Wiki[currentRecordIndex].GetCategory();
            textBoxDefinition.Text= Wiki[currentRecordIndex].GetDefinition();
            SetStructureForExisting(currentRecordIndex);
        }

        // 6.4 Create and initialise a global string array with the six categories as indicated in the Data Structure Matrix.
        // Create a custom method to populate the ComboBox when the Form Load method is called.
        private void WikiForm_Load(object sender, EventArgs e)
        {
            ReadCategoriesFromFile();
            FillComboBoxCategories();

            string filename = Path.Combine(Application.StartupPath, "Wiki.bin");
            if (File.Exists(filename))
            {
                if (!OpenBinaryFile(filename))
                {
                    // if here, means the file Wiki.bin has nothing in it. It has been overwritten.
                    CreateOriginalWiki();
                    DisplayWiki();
                }
            }
            else
            {
                CreateOriginalWiki();
                DisplayWiki();
            }
        }

        #endregion
    } // end class Form
} // end namespace DataStructuresWiki2
