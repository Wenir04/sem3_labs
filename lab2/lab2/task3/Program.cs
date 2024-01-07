using System; 

public class DocumentWorker
{
    public void OpenDocument()
    {
        Console.WriteLine("Документ открыт\n");
    }

    public virtual void EditDocument()
    {
        Console.WriteLine("Редактирование документа доступно в версии Pro\n");
    }

    public virtual void SaveDocument()
    {
        Console.WriteLine("Сохранение документа доступно в версии Pro\n");
    }
}


public class ExpertDocumentWorker : ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате\n");
    }
}


public class ProDocumentWorker : DocumentWorker
{

    public override void EditDocument()
    {
        Console.WriteLine("Документ отредактирован\n");
    }

    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно" +
                          " в версии Expert\n");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите ключ: ");
        string? key = Console.ReadLine();

        DocumentWorker doc = KeyCheck(key);

        doc.OpenDocument();
        doc.EditDocument();
        doc.SaveDocument();
    }

    static DocumentWorker KeyCheck(string input)
    {
        switch (input)
        {
            case "pro":
                return new ProDocumentWorker();
            case "exp":
                return new ExpertDocumentWorker();
        }

        return new DocumentWorker();
    }
}