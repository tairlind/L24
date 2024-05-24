using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    public interface IRenderStrategy // Интерфейс для стратегии отрисовки
    {
        string Render(List<string> items);
    }

    public class HtmlRenderStrategy : IRenderStrategy // Стратегия для отрисовки в виде списка HTML
    {
        public string Render(List<string> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach (string item in items)
            {
                sb.Append($"<li>{item}</li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
    }

    public class LaTeXRenderStrategy : IRenderStrategy // Стратегия для отрисовки в виде списка LaTeX
    {
        public string Render(List<string> items)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\\begin{itemize}");
            foreach (string item in items)
            {
                sb.Append($"\\item {item}");
            }
            sb.Append("\\end{itemize}");
            return sb.ToString();
        }
    }

    public class ListRenderer // Класс, использующий стратегию
    {
        private IRenderStrategy renderStrategy;

        public ListRenderer(IRenderStrategy renderStrategy)
        {
            this.renderStrategy = renderStrategy;
        }

        public string RenderList(List<string> items)
        {
            return renderStrategy.Render(items);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string> { "Item 1", "Item 2", "Item 3" }; // Создаем список элементов

            ListRenderer htmlRenderer = new ListRenderer(new HtmlRenderStrategy()); // Создаем рендерер с HTML-стратегией
            string htmlOutput = htmlRenderer.RenderList(items);
            Console.WriteLine("HTML Output:");
            Console.WriteLine(htmlOutput);

            ListRenderer latexRenderer = new ListRenderer(new LaTeXRenderStrategy()); // Создаем рендерер с LaTeX-стратегией
            string latexOutput = latexRenderer.RenderList(items);
            Console.WriteLine("LaTeX Output:");
            Console.WriteLine(latexOutput);

            Console.ReadLine();
        }
    }
}
