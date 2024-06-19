using GraduationProject.DataBase;
using GraduationProject.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MudBlazor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GraduationProject.Services
{
    public class ReportService
    {
        #region Declaration
        private GraduationProjectContext _context;
        int _maxColumnOne = 5;
        int _maxColumnTwo = 2;
        Document _document;
        PdfPTable _pdfPTableOne = new PdfPTable(5);
        PdfPTable _pdfPTableTwo = new PdfPTable(2);
        PdfPTable _pdfPTableThree = new PdfPTable(2);
        PdfPCell _pdfPCell;
        Font _fontStyle;
        MemoryStream _memoryStream = new MemoryStream();
        List<Aviary> _aviaries = new List<Aviary>();
        Role _currentRole;
        User _currentUser;
        Report _currentReport;
        double _currentWater;
        public string[] _labels = new string[] { };
        public double[] _data = new double[] { };
        List<string> _names = new List<string>();
        List<string> _descriptions = new List<string>();
        #endregion

        public byte[] CreateReport(GraduationProjectContext context, List<Aviary> aviaries, double[] data, string[] labels, Role currentRole, User currentUser, Report currentReport, double currentWater, List<string> names, List<string> descriptions)
        {
            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            _fontStyle = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
            _context = context;
            _aviaries = aviaries;
            _data = data;
            _labels = labels;
            _currentRole = currentRole;
            _currentUser = currentUser;
            _currentReport = currentReport;
            _currentWater = currentWater;
            _names = names;
            _descriptions = descriptions;
            _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
            //_pdfPTable.WidthPercentage= 100;
            //_pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();

            float[] sizesOne = new float[_maxColumnOne];
            for (int i = 0; i < _maxColumnOne; i++)
            {
                if (i == 0) sizesOne[i] = 50;
                else sizesOne[i] = 100;
            }

            float[] sizesTwo = new float[_maxColumnTwo];
            for (int i = 0; i < _maxColumnTwo; i++)
            {
                if (i == 0) sizesTwo[i] = 50;
                else sizesTwo[i] = 100;
            }

            _pdfPTableOne.SetWidths(sizesOne);
            _pdfPTableTwo.SetWidths(sizesTwo);
            _pdfPTableThree.SetWidths(sizesTwo);

            this.ReportHeader(1);
            this.ReportBodyOne();
            this.ReportHeader(2);
            this.ReportBodyTwo();
            //this.ReportHeader(3);
            //this.ReportBodyThree();
            this.ReportHeader(4);

            _pdfPTableOne.HeaderRows = 2;
            _pdfPTableTwo.HeaderRows = 2;
            _pdfPTableThree.HeaderRows = 2;
            _document.Add(_pdfPTableOne);
            _document.Add(_pdfPTableTwo);
            _document.Add(_pdfPTableThree);
            _document.Close();

            return _memoryStream.ToArray();

        }

        private void ReportHeader(int count)
        {
            //_pdfPCell = new PdfPCell(this.AddLogo());
            //_pdfPCell.Colspan = 1;
            //_pdfPCell.Border = 0;
            //_pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(this.SetPageTitle(count));
            //_pdfPCell.Colspan = _maxColumn - 1;
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            switch (count)
            {
                case 1:
                    _pdfPTableOne.AddCell(_pdfPCell);
                    _pdfPTableOne.CompleteRow();
                    break;
                case 2:
                    _pdfPTableTwo.AddCell(_pdfPCell);
                    _pdfPTableTwo.CompleteRow();
                    break;
                case 3:
                    _pdfPTableThree.AddCell(_pdfPCell);
                    _pdfPTableThree.CompleteRow();
                    break;
                case 4:
                    _pdfPTableOne.AddCell(_pdfPCell);
                    _pdfPTableOne.CompleteRow();
                    break;
            }
            
        }

        private PdfPTable AddLogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            string imgCombine = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images\Лого.png"}";
            Image img = Image.GetInstance(imgCombine);
            _pdfPCell = new PdfPCell(img);
            _pdfPCell.Colspan = maxColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfPCell);

            pdfPTable.CompleteRow();
            return pdfPTable;
        }

        private PdfPTable SetPageTitle(int count)
        {
            int maxColumn = 2;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            switch (count)
            {
                case 1:
                    Paragraph titolo = new Paragraph($"Отчет №{_currentReport.Id}\n\n", _fontStyle);
                    Paragraph dateText = new Paragraph($"Дата: {_currentReport.Date.ToString("d")}\n", _fontStyle);
                    Paragraph roleText = new Paragraph($"Должность: {_currentRole.Title}\n", _fontStyle);
                    Paragraph nameText = new Paragraph($"ФИО: {_currentUser.Surname} {_currentUser.Name} {_currentUser.Patronymic} ", _fontStyle);
                    Paragraph tableTitolo = new Paragraph($"\nОтчетная таблица", _fontStyle);

                    _pdfPCell = new PdfPCell(new Phrase(titolo));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();

                    _pdfPCell = new PdfPCell(new Phrase(dateText));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();

                    _pdfPCell = new PdfPCell(new Phrase(roleText));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();

                    _pdfPCell = new PdfPCell(new Phrase(nameText));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();

                    _pdfPCell = new PdfPCell(new Phrase(tableTitolo));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();
                    break;
                case 2:
                    Paragraph titoloTwo = new Paragraph("\nТаблица расхода продуктов питания", _fontStyle);
                    Paragraph water = new Paragraph($"Общий расход воды: {_currentWater}л", _fontStyle);

                    _pdfPCell = new PdfPCell(new Phrase(titoloTwo));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();

                    _pdfPCell = new PdfPCell(new Phrase(water));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();
                    break;
                case 3:
                    Paragraph titoloThree = new Paragraph("\nТаблица состояния животных", _fontStyle);

                    _pdfPCell = new PdfPCell(new Phrase(titoloThree));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();
                    break;
                case 4:
                    Paragraph addition = new Paragraph($"\nДополнительно: {_currentReport.Description}", _fontStyle);

                    _pdfPCell = new PdfPCell(new Phrase(addition));
                    _pdfPCell.Colspan = maxColumn;
                    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    _pdfPCell.Border = 0;
                    _pdfPCell.ExtraParagraphSpace = 0;
                    pdfPTable.AddCell(_pdfPCell);

                    pdfPTable.CompleteRow();
                    break;
            }

            return pdfPTable;
        }

        private void ReportBodyOne()
        {
            #region Table Header
            _pdfPCell = new PdfPCell(new Phrase("Номер вольера", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableOne.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Название вольера", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableOne.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Вид вольера", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableOne.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Вид животных", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableOne.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Количество животных", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableOne.AddCell(_pdfPCell);
            #endregion

            #region Table Body
            foreach (var aviary in _aviaries)
            {
                _pdfPCell = new PdfPCell(new Phrase(aviary.Id.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfPTableOne.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(aviary.Title, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfPTableOne.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(GetType(aviary), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfPTableOne.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(GetKind(aviary), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfPTableOne.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(GetCount(aviary), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.White;
                _pdfPTableOne.AddCell(_pdfPCell);
            }
            #endregion
        }

        private void ReportBodyTwo()
        {
            #region Table Header
            _pdfPCell = new PdfPCell(new Phrase("Продукт питания", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableTwo.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Расход (кг)", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableTwo.AddCell(_pdfPCell);
            #endregion

            #region Table Body
            int i = 1;
            int j = 0;
            foreach (var label in _labels)
            {
                j = 0;
                foreach (var data in _data)
                {
                    j++;
                    if (i == j)
                    {
                        _pdfPCell = new PdfPCell(new Phrase(label, _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.White;
                        _pdfPTableTwo.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(data.ToString(), _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.White;
                        _pdfPTableTwo.AddCell(_pdfPCell);
                    }
                }
                i++;
            }
            #endregion
        }

        private void ReportBodyThree()
        {
            #region Table Header
            _pdfPCell = new PdfPCell(new Phrase("Имя животного", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableThree.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Описание", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.Gray;
            _pdfPTableThree.AddCell(_pdfPCell);
            #endregion

            #region Table Body
            int i = 1;
            int j = 0;
            foreach (var name in _names)
            {
                j = 0;
                foreach (var description in _descriptions)
                {
                    j++;
                    if (i == j)
                    {
                        _pdfPCell = new PdfPCell(new Phrase(name, _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.White;
                        _pdfPTableThree.AddCell(_pdfPCell);

                        _pdfPCell = new PdfPCell(new Phrase(description, _fontStyle));
                        _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        _pdfPCell.BackgroundColor = BaseColor.White;
                        _pdfPTableThree.AddCell(_pdfPCell);
                    }
                }
                i++;
            }
            #endregion
        }

        private string GetType(Aviary aviary) => _context.TypeAviaries.FirstOrDefault(x => x.Id == aviary.TypeId).Title;

        private string GetKind(Aviary aviary) => _context.AnimalKinds.FirstOrDefault(x => x.Id == aviary.KindId).Title;

        private string GetCount(Aviary aviary) => _context.Animals.Where(x => x.AviaryId == aviary.Id && x.IsDeleted == false).ToList().Count.ToString();
    }
}
