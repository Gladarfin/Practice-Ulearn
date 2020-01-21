using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public class ParsingTask
    {
        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка заголовочная.</param>
        /// <returns>Словарь: ключ — идентификатор слайда, значение — информация о слайде</returns>
        /// <remarks>Метод должен пропускать некорректные строки, игнорируя их</remarks>
        public static IDictionary<int, SlideRecord> ParseSlideRecords(IEnumerable<string> lines)
        {
            return lines
                .Skip(1)
                .Select(line => line.Split(';'))
                .Select(IsCorrectSlide)
                .Where(tuple => tuple != null)
                .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
        }

        private static Tuple<int, SlideRecord> IsCorrectSlide(string[] columns)
        {
            int id = 0;
            SlideType slideType = default(SlideType);
            return ((columns.Length == 3) &&
                (int.TryParse(columns[0], out id)) &&
                (Enum.TryParse(columns[1], true, out slideType)) &&
                (columns[2] != null)) ?
                Tuple.Create(id, new SlideRecord(id, slideType, columns[2])) :
                null;
        }

        private static SlideRecord CreateSlideRecord(int id, SlideType newSlydeType, string title)
        {
            return new SlideRecord(id, newSlydeType, title);
        }

        /// <param name="lines">все строки файла, которые нужно распарсить. Первая строка — заголовочная.</param>
        /// <param name="slides">Словарь информации о слайдах по идентификатору слайда. 
        /// Такой словарь можно получить методом ParseSlideRecords</param>
        /// <returns>Список информации о посещениях</returns>
        /// <exception cref="FormatException">Если среди строк есть некорректные</exception>
        public static IEnumerable<VisitRecord> ParseVisitRecords(
            IEnumerable<string> lines, IDictionary<int, SlideRecord> slides)
        {
            return lines
                .Skip(1)
                .Select(line => CreateRecord(line, slides));
        }

        public static VisitRecord CreateRecord(string line, IDictionary<int, SlideRecord> slides)
        {
            var columns = line.Split(';');
            int userID = int.MinValue;
            int slideID = int.MinValue;
            DateTime dateAndTime = new DateTime(9999, 12, 31, 12, 12, 12);
            if (columns.Length != 4 ||
                !int.TryParse(columns[0], out userID) ||
                !int.TryParse(columns[1], out slideID) ||
                !slides.ContainsKey(slideID) ||
                !DateTime.TryParse(columns[2] + " " + columns[3], out dateAndTime))
            {
                throw new FormatException($"Wrong line [{line}]");
            }
            return new VisitRecord(userID, slideID, dateAndTime, slides[slideID].SlideType);
        }
    }
}