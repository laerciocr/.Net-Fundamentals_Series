using System;
using App_Series.Classes;

namespace App_Series {
    class Program {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args) {

            string opcaoUsuario = obterOpcaoUsuario();

			while (opcaoUsuario != "x") {
				switch (opcaoUsuario) {
					case "1":
						listarSeries(); break;
					case "2":
						inserirSerie(); break;
					case "3":
						atualizarSerie(); break;
					case "4":
						excluirSerie(); break;
					case "5":
						VisualizarSerie(); break;
					case "c":
						Console.Clear(); break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = obterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void excluirSerie() {
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.exclui(indiceSerie);
		}

        private static void VisualizarSerie() {
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.retornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void atualizarSerie() {
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0
			foreach (int i in Enum.GetValues(typeof(Genero))) {
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(indiceSerie, (Genero)entradaGenero,
										entradaTitulo, ano: entradaAno,
                                        descricao: entradaDescricao);

			repositorio.atualiza(indiceSerie, atualizaSerie);
		}
        private static void listarSeries() {
			Console.WriteLine("Listar séries");

			var lista = repositorio.lista();

			if (lista.Count == 0) {
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista) {
                var excluido = serie.retornaExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void inserirSerie() {
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero))) {
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(repositorio.proximoId(), (Genero)entradaGenero,
										entradaTitulo, ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.insere(novaSerie);
		}

        private static string obterOpcaoUsuario() {

			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1 - Listar séries");
			Console.WriteLine("2 - Inserir nova série");
			Console.WriteLine("3 - Atualizar série");
			Console.WriteLine("4 - Excluir série");
			Console.WriteLine("5 - Visualizar série");
			Console.WriteLine("c - Limpar Tela");
			Console.WriteLine("x - Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
