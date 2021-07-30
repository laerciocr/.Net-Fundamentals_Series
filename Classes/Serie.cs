using System;
namespace App_Series {
	public class Serie : EntidadeBase {
		private Genero _genero { get; set; }
		private string _titulo { get; set; }
		private string _descricao { get; set; }
		private int _ano { get; set; }
		private bool _excluido {get; set;}

		public Serie(int id, Genero genero, string titulo, string descricao, int ano) {
			Id = id;
			_genero = genero;
			_titulo = titulo;
			_descricao = descricao;
			_ano = ano;
			_excluido = false;
		}

		public override string ToString() {
		// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=net-5.0
			string retorno = "";
			retorno += "Gênero: " + _genero + Environment.NewLine;
			retorno += "Titulo: " + _titulo + Environment.NewLine;
			retorno += "Descrição: " + _descricao + Environment.NewLine;
			retorno += "Ano de Início: " + _ano + Environment.NewLine;
			retorno += "Excluido: " + _excluido;
			return retorno;
		}
			
		public string retornaTitulo() {
			return _titulo;
		}

		public int retornaId() {
			return Id;
		}
		public bool retornaExcluido() {
			return _excluido;
		}
		public void excluir() {
			_excluido = true;
		}

  }
}