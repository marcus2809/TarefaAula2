
List<Cadastro> usuarios = new List<Cadastro>();
Cadastro.Usuarios = usuarios;

Cadastro.CadastrarUsuario();

while (true)
{
    Console.WriteLine("Digite 1 caso deseje cadastrar outro usuario, 2 caso deseje fazer login ou 3 caso deseje sair");
    string acao = Console.ReadLine();

    switch (acao)
    {
        case "1":
            Cadastro.CadastrarUsuario();
            break;
        case "2":
            Cadastro.FazerLogin();
            break;
        default:
            Environment.Exit(-1);
            break;
    }
}

class Cadastro
{
    public string Login { get; set; }
    public string Senha { get; set; }

    public static List<Cadastro> Usuarios;

    public Cadastro(string login, string senha)
    {
        Login= login;
        Senha= senha;
    }

    public static void CadastrarUsuario()
    {
        Console.WriteLine("Insira o login do cadastro");
        string login = Console.ReadLine();
        string senha;

        do
        {
            Console.WriteLine("Insira a senha");
            senha = Console.ReadLine();
        } while (senha.Length < 4 || senha.Length > 8);

        string senhaConfirmada;

        do
        {
            Console.WriteLine("Confirme a senha");
            senhaConfirmada = Console.ReadLine();

        } while (senha != senhaConfirmada);

        Usuarios.Add(new Cadastro(login, senha));
    }

    public static void FazerLogin()
    {
        Console.WriteLine("Insira o login");
        string login = Console.ReadLine();

        var usuario = Usuarios.FirstOrDefault(x => x.Login == login);

        if (usuario == null)
        {
            Console.WriteLine("Usuário não existe");
            return;
        }

        string senha;
        int tentativas = 0;

        do
        {
            Console.WriteLine("Insira a senha");
            senha = Console.ReadLine();
            if(usuario.Senha == senha)
            {
                Console.WriteLine("Usuário logado");
                return;
            }
            Console.WriteLine("Senha incorreta");
            tentativas++;
        } while (tentativas < 3);
    }
}