namespace GradeBook
{
  public class DiskBook : Book
  {
    public string teacherName;
    public string studentName;
    public string subject;

    public DiskBook(string teacherName, string studentName, string subject) : base(teacherName, studentName, subject)
    {
      this.teacherName = teacherName;
      this.studentName = studentName;
      this.subject = subject;
    }

    public override string AddGrade(double grade)
    {
      return grade.ToString();
    }

    public override void ListGrades()
    {
      throw new System.NotImplementedException();
    }

    public override string PrintStats(Book book)
    {
      return PrintStat.PrintStatistics(book);
    }
  }
}