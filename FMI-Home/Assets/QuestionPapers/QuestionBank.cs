using UnityEngine;
using System.Collections.Generic;

public class QuestionBank
{
    private List<QuestionData> questions;

    // Constructor to initialize the question bank
    public QuestionBank()
    {
        questions = new List<QuestionData>();

        // Initialize your questions here
        AddQuestion("What does 'inheritance' in OOP represent?", "The ability of a class to derive properties and characteristics from another class", "A method of formatting code", 0);
        AddQuestion("Which principle of OOP is demonstrated by encapsulating data and methods within classes?", "Polymorphism", "Encapsulation", 1);
        AddQuestion("What is an instance of a class in OOP known as?", "Function", "Object", 1);
        AddQuestion("Which OOP concept allows different classes to be treated as instances of the same class through inheritance?", "Encapsulation", "Polymorphism", 1);
        AddQuestion("In OOP, what is a 'constructor' used for?", "Deleting objects from memory", "Initializing new objects", 1);
        AddQuestion("Which access modifier in many OOP languages signifies that a member is accessible only within its own class?", "Private", "Public", 0);
        AddQuestion("What is the sum of the interior angles of a triangle?", "180 degrees", "360 degrees", 0);
        AddQuestion("Which theorem is used to calculate the distance between two points in a coordinate plane?", "Pythagorean Theorem", "Fermat's Last Theorem", 0);
        AddQuestion("What term describes a polygon with all sides and angles equal?", "Regular Polygon", "Irregular Polygon", 0);
        AddQuestion("In Euclidean geometry, how many degrees are in the sum of the angles of a quadrilateral?", "360 degrees", "180 degrees", 0);
        AddQuestion("What is the formula to calculate the area of a circle?", "pi*r^2", "2*pi*r", 0);
        AddQuestion("Which geometric concept is defined as the set of all points in a plane at a given distance from a given point?", "Circle", "Polygon", 0);
        AddQuestion("What is a Finite Automaton?", "A mathematical model of computation that performs calculations automatically", "A device that automatically supplies a constant voltage", 0);
        AddQuestion("Which of the following is NOT a type of automaton?", "Deterministic Finite Automaton (DFA)", "Recursive Enumerable Automaton (REA)", 1);
        AddQuestion("In the context of automata theory, what does DFA stand for?", "Deterministic Finite Automaton", "Dynamic Frequency Adjustment", 0);
        AddQuestion("What does the Regular Expression (0|1)* represent?", "Any string of 0s and 1s, including the empty string", "A string of 0s followed by a string of 1s", 0);
        AddQuestion("What is the Pumping Lemma used for in the context of regular languages?", "To prove that certain languages are not regular", "To pump more data into a regular expression", 0);
        AddQuestion("Which automaton is equivalent to a Regular Expression in terms of the languages they can represent?", "Non-deterministic Finite Automaton (NFA)", "Turing Machine", 0);

        // Add more questions as needed
    }

    private void AddQuestion(string questionText, string answerA, string answerB, int correctAnswer)
    {
        QuestionData newQuestion = ScriptableObject.CreateInstance<QuestionData>();
        newQuestion.questionText = questionText;
        newQuestion.answerA = answerA;
        newQuestion.answerB = answerB;
        newQuestion.correctAnswer = correctAnswer;
        questions.Add(newQuestion);
    }

    // Method to get a random question from the bank
    public QuestionData GetRandomQuestion()
    {
        if (questions.Count == 0)
        {
            Debug.LogError("No questions available.");
            return null;
        }

        int randomIndex = Random.Range(0, questions.Count);
        return questions[randomIndex];
    }
}
