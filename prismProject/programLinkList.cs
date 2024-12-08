using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class programLinkList
{
    public string programType { get; set; }
    public string softwareName { get; set; }
    public programLinkList Next { get; set; }

    public programLinkList(string programTypes, string software)
    {
        programType = programTypes;
        softwareName = software;
        Next = null;
    }
}

public class LinkedList
{
    private programLinkList head;

    public LinkedList()
    {
        head = null;
    }
    //add to the linked list
    public void Add(string programType, string software)
    {
        programLinkList newNode = new programLinkList(programType, software);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            programLinkList current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }
    // get the programs
    public IEnumerable<string> GetProgramTypes()
    {
        HashSet<string> programTypes = new HashSet<string>();
        programLinkList current = head;
        while (current != null)
        {
            programTypes.Add(current.programType);
            current = current.Next;
        }
        return programTypes;
    }
    //Get the program by their type
    public IEnumerable<string> GetProgramsByType(string programType)
    {
        List<string> programs = new List<string>();
        programLinkList current = head;
        while (current != null)
        {
            if (current.programType == programType)
            {
                programs.Add(current.softwareName);
            }
            current = current.Next;
        }
        return programs;
    }
}
