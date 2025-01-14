﻿using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

try
{
    var context = new ScreenSoundContext();
    var artistaDAL = new ArtistaDAL(context);

    var novoArtista = new Artista("Nadson o ferinha", "Nadson de Jesus Alves, mais conhecido por seu nome artístico," +
        " Nadson O Ferinha, é um cantor e compositor brasileiro de arrocha.") { Id = 3002 };

    artistaDAL.Atualizar(novoArtista);
    artistaDAL.Deletar(novoArtista);   
    
    
    var listaArtistas = artistaDAL.Listar();

    foreach (var artist in listaArtistas )
    {
        Console.WriteLine( artist );
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);

    return;

    Artista ira = new Artista("Ira!", "Banda Ira!");
    Artista beatles = new("The Beatles", "Banda The Beatles");

    Dictionary<string, Artista> artistasRegistrados = new();
    artistasRegistrados.Add(ira.Nome, ira);
    artistasRegistrados.Add(beatles.Nome, beatles);

    Dictionary<int, Menu> opcoes = new();
    opcoes.Add(1, new MenuRegistrarArtista());
    opcoes.Add(2, new MenuRegistrarMusica());
    opcoes.Add(3, new MenuMostrarArtistas());
    opcoes.Add(4, new MenuMostrarMusicas());
    opcoes.Add(-1, new MenuSair());

    void ExibirLogo()
    {
        Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
        Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
    }

    void ExibirOpcoesDoMenu()
    {
        ExibirLogo();
        Console.WriteLine("\nDigite 1 para registrar um artista");
        Console.WriteLine("Digite 2 para registrar a música de um artista");
        Console.WriteLine("Digite 3 para mostrar todos os artistas");
        Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

        if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
        {
            Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
            menuASerExibido.Executar(artistasRegistrados);
            if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("Opção inválida");
        }
    }

    ExibirOpcoesDoMenu();
}