using System.Windows.Forms;
using TestDataGeneratorApp.Presenters;
using TestDataGeneratorApp.Views;

namespace GeneratorAppTest;

public class FileNamePresTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SetFileName_NoFileTypeProvided_DefaultFileTypeAdded()
    {
        //Arrange
        MockFileNameForm Form = new();
        FileNamePresenter Presenter = new(Form);

        Form.EnteredFileName = "myfilename";

        string ExpectedFileName = $"\\myfilename.dat";

        //Act
        Form.FileNameForm_FormClosing();

        //Assert
        Assert.That(Form.FileName, Is.EqualTo(ExpectedFileName));
    }

    [Test]
    public void SetFileName_FileTypeProvided_DefaultFileTypeNotAdded()
    {
        //Arrange
        MockFileNameForm Form = new();
        FileNamePresenter Presenter = new(Form);

        Form.EnteredFileName = "myfilename.txt";

        string ExpectedFileName = $"\\myfilename.txt";

        //Act
        Form.FileNameForm_FormClosing();

        //Assert
        Assert.That(Form.FileName, Is.EqualTo(ExpectedFileName));
    }
}

class MockFileNameForm : IFileNameView
{
    private string _file_name = "";
    private string _entered_file_name = "";
    private string explain = "";
    public string EnteredFileName { get => _entered_file_name; set => _entered_file_name = value; }
    public string FileName { get => _file_name; set => _file_name = value; }
    public string DefaultFileTypeExplain { get => explain; set => explain = value; }

    public event EventHandler? ValidateFileName;
    public event EventHandler? LoadView;

    public void FileNameForm_FormClosing()
    {
        ValidateFileName?.Invoke(this, EventArgs.Empty);
    }
    public void FileNameForm_Load()
    {
        LoadView?.Invoke(this, EventArgs.Empty);
    }
    public void ShowAsDialogue()
    {
        throw new NotImplementedException();
    }
}
