using Microsoft.AspNetCore.Components;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace McQuestions.Shared
{
	public static class Extensions 
	{
		public static MarkupString AsMarkup(this string s)
		{
			return (MarkupString)s;
		}
	}

	public class McObject 
	{

		public McObject(string filename) 
		{
			FileName = filename;
			//Niveau = niveau;
			filename = filename.Replace("{", "").Replace("}", "");
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string fullpath = Path.Combine(Directory.GetCurrentDirectory() + "\\XmlQuestions\\", filename);
            var xmlString = File.ReadAllText(fullpath);
            Root = XElement.Parse(xmlString);
            
            NaamVragenSet = Root.Element("vragenset").Value;
			
        }

		public  XElement Root { get; set; }

        public  List<XElement>? XmlQuestionsLevelSpecified { get; set; }

		public  string Niveau { get; set; }

		public  string FileName { get; set; }

		public  string NaamVragenSet { get; set; }

		private int randomNumber;

		public void SetLevelTestQuestions(string niveau)
		{
			Niveau = niveau;
			var allEnabledQuestions = Root.Elements("vraag").Distinct().Where(e => e.Element("disabled").Value != "true").ToList();
			XmlQuestionsLevelSpecified = allEnabledQuestions.FindAll(l => l.Element("niveau").Value == niveau);
		}

		public int TotalQuestionsLevelSpecified()
		{
			return XmlQuestionsLevelSpecified.Count();
		}





	}


}
