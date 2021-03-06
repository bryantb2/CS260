﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class ArrayInt
    {
        //fields (variables specific to the class)
        private int?[] array;
        private int size = 0;

        //tracking if methods/proeprties have been used
        private bool wasAppendUsed = false;
        private int lastAppendLocation = 0;
        private bool wasSetAtUsed = false;
        private int largestSetAtIndex = 0;
        private bool haveItemsBeenAdded = false;

        //default constructor
        public ArrayInt()
        {
            array = new int?[10];
            size = 10;
        }

        //constructor with user defined size
        public ArrayInt(int arraySize)
        {
             //this sets the value for the size field
            if (arraySize < 1)
            {
                array = new int?[10];
                this.size = 10;
            }
            else
            {
                array = new int?[arraySize];
                this.size = arraySize;
            }
        }

        //Properties
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                if (value > size)
                {
                    //creates new array that the new values will be copied into
                    //copy values from class array into the new one
                    //sets new array equal to the class array
                    //sets the size to the new value

                    int?[] newArray = new int?[value];
                    for(int i = 0; i < size; i++) //this steps through the old array and places values into new array
                    {
                        newArray[i] = array[i];
                    }
                    array = newArray;
                    size = value;
                }
            }
        }

        public int this[int i] //this uses the bracket notation to access and set values
        {
            get
            {
                if (i > size || i < 0)
                {
                    throw new ArgumentOutOfRangeException("index is out of bounds");
                }
                else
                {
                    return (int)array[i];
                }
            }
            set
            {
                if (i > size || i < 0)
                {
                    throw new ArgumentOutOfRangeException("index is out of bounds");
                }
                else
                {
                    //sets array element equal to the provided value
                    //turns was setAt to true and records the largest index value
                    //sets haveItemsBeenAdded to true
                    array[i] = value;
                    if (wasSetAtUsed == false)
                    {
                        wasSetAtUsed = true;
                    }

                    if (i > largestSetAtIndex )
                    {
                        largestSetAtIndex = i;
                    }

                    if (haveItemsBeenAdded == false)
                    {
                        haveItemsBeenAdded = true;
                    }
                }
            }
        }

        //methods
        public bool IsFull()
        {
            int fullTracker = 0; //this is to keep track of the amount of 
            bool isFull = false;
            for(int i = 0; i < size; i++)
            {
                if (array[i] != null) //increments the tracker total if the element contains no value
                {
                    fullTracker++;
                }
            }
            if (fullTracker == size) //if the 
            {
                isFull = true;
            } 
            return isFull;
        }

        public bool IsEmpty()
        {
            int emptyTracker = 0; //this is to keep track of the amount of 
            bool isEmpty = false;
            for (int i = 0; i < size; i++)
            {
                if (array[i] == null) //increments the tracker total if the element contains no value
                {
                    emptyTracker++;
                }
            }
            if (emptyTracker == size) //if the 
            {
                isEmpty = true;
            }
            return isEmpty;
        }

        public void Append(int v)
        {
            if (IsFull() == true)
            {
                int?[] newArray = new int?[size * 2];
                for (int i = 0; i < size; i++)
                {
                    newArray[i] = array[i];
                }
                size = size * 2;
            }
            if (wasSetAtUsed == true)
            {
                int appendLocation = largestSetAtIndex + 1;
                int?[] newArray = new int?[size + 1]; //appends the value after the OG appended value (adds 1 to the count)
                newArray[appendLocation] = v;
                for (int i = 0; i < appendLocation; i++)
                {
                    newArray[i] = array[i];
                }
                size++;
                array = newArray;
            }
            else if (wasSetAtUsed == false && wasAppendUsed == true)
            {
                lastAppendLocation++;
                int?[] newArray = new int?[size + 1]; //appends the value after the OG appended value (adds 1 to the count)
                newArray[lastAppendLocation] = v;
                size++;
                for (int i =0; i < lastAppendLocation; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            else if (IsEmpty() == true)
            { 
                int?[] newArray = new int?[size + 1]; //appends the value to the beginning (adds 1 to the count)
                newArray[0] = v;
                size++;
                array = newArray;
                wasAppendUsed = true; //this allows the code path to then append the next location
            }
        }

        public void InsertAt(int index, int value)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index must be greater than zero and less than the array size");
            }
            else
            {
                if (IsFull() == true)
                {
                    int?[] newArray = new int?[size * 2];
                    for (int i = 0; i < size; i++)
                    {
                        newArray[i] = array[i];
                    }
                    size = size * 2;
                    array = newArray;
                }
                //create new array to copy values
                //add all values before the index to the new array
                //insert the new value at the specificed index
                //Add remaining OG values to array
                int?[] newerArray = new int?[size * 2];
                if (index != 0 && index != (size -1))
                {
                    for (int i = 0; i < index; i++)
                    {
                        newerArray[i] = array[i];
                    }
                    newerArray[index] = value;
                    for (int j = (index+1); j < size; j++)
                    {
                        newerArray[j] = array[j - 1];
                    }
                    size = size++;
                    array = newerArray;
                }
                else if (index == 0)
                {
                    newerArray[index] = value;
                    for (int i = 1; i < size; i++)
                    {
                        newerArray[i] = array[i -1];
                    }
                    size = size++;
                    array = newerArray;
                }
                else if (index == (size -1))
                {
                    for (int i = 0; i < (index -1); i++)
                    {
                        newerArray[i] = array[i];
                    }
                    newerArray[index] = value;
                    newerArray[index + 1] = array[index];
                    size = size++;
                    array = newerArray;
                }

            }
            

        }

        public int RemoveAt(int index)
        {
            if (index < 0 || index >= size || IsEmpty() == true)
            {
                throw new ArgumentOutOfRangeException("Index must be greater than zero and less than the array size; element must also contain a value");
            }
            else
            {
                //create new array to copy values
                //add all values before the index to the new array
                //insert the new value at the specificed index
                //Add remaining OG values to array
                int?[] newerArray = new int?[size * 2];
                int removedValue;
                if (index != 0 && index != (size - 1))
                {
                    for (int i = 0; i < index; i++)
                    {
                        newerArray[i] = array[i];
                    }
                    for (int j = (index + 1); j < size; j++)
                    {
                        newerArray[j - 1] = array[j];
                    }
                    removedValue = index;
                    size = size++;
                    array = newerArray;
                    return removedValue;
                }
                else if (index == 0)
                {
                    newerArray[index] = array[index + 1];
                    for (int i = 1; i < size; i++)
                    {
                        newerArray[i] = array[i + 1];
                    }
                    removedValue = index;
                    size = size++;
                    array = newerArray;
                    return removedValue;
                }

                else if (index == (size - 1))
                {
                    for (int i = 0; i < (index); i++)
                    {
                        newerArray[i] = array[i];
                    }
                    removedValue = index;
                    size = size++;
                    array = newerArray;
                    return removedValue;
                }
                return -1; //if this is returned, there is an error
            }
            
        }

        public string GetDisplayText(string sep)
        {
            string finalOutput = "";
            for (int i = 0; i < size; i++)
            {
                finalOutput += array[i].ToString();
                if (i >= 0 && i < (size -1))
                {
                    finalOutput += sep;
                }
            }
            return finalOutput;
        }

    }
}
