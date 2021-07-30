using System;
using System.Collections.Generic;
using App_Series.Interfaces;

namespace App_Series.Classes {
	public class SerieRepositorio : IRepositorio<Serie> {
        private List<Serie> listaSerie = new List<Serie>();
		public void atualiza(int id, Serie elemento) {
			listaSerie[id] = elemento;
		}

		public void exclui(int id) {
			listaSerie[id].excluir();
		}

		public void insere(Serie objeto) {
			listaSerie.Add(objeto);
		}

		public List<Serie> lista() {
			return listaSerie;
		}

		public int proximoId() {
			return listaSerie.Count;
		}

		public Serie retornaPorId(int id) {
			return listaSerie[id];
		}
	}
}