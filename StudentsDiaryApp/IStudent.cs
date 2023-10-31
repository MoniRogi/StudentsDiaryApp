

namespace StudentsDiaryApp

{
    public interface IStudent
    {
        string Name { get; }
        string Surname { get; }
        string Sex { get; }

        void AddGrade(float grade);
        void AddGrade(double grade);
        void AddGrade(int grade);
        void AddGrade(string grade);

        event StudentBase.GradeAddedDelegate GradeAdded;

        Statistics GetStatistics();
    }

}