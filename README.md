# Cadastro de Eventos - .NET MAUI
## Atividade Avaliativa - Agenda 15 (Desenvolvimento de Sistemas II)

Olá, professor! Este projeto foi desenvolvido por mim como parte das atividades da Agenda 15 do curso técnico. O objetivo principal foi criar um aplicativo móvel multiplataforma usando o framework **.NET MAUI** para cadastrar eventos, calcular automaticamente a duração e os custos envolvidos, e exibir um resumo completo e formatado em uma segunda tela.

Como desenvolvedor iniciante (nível Júnior), foquei em aplicar as melhores práticas de codificação, mantendo a estrutura organizada e o código bem documentado para que o fluxo de dados fique nítido e fácil de compreender.

---

## 📱 Sobre a Aplicação

O aplicativo foi projetado para ser intuitivo, bonito e responsivo. Ele é composto por duas telas principais:

1. **Tela de Cadastro (`CadastroPage`)**: Contém um formulário onde o usuário preenche o nome do evento, local, data de início, data de término, quantidade de participantes e o custo individual por pessoa.
2. **Tela de Resumo (`ResumoPage`)**: Exibe as informações que o usuário digitou, organizadas em "cards" visuais elegantes, destacando os valores calculados de forma automática (a duração total do evento em dias e o custo total do investimento).

---

## 🛠️ Como Funciona a Tecnologia do Projeto

Para atender aos requisitos solicitados na atividade, implementei as seguintes soluções:

### 1. Associação de Dados com `BindingContext`
Na página de cadastro (`CadastroPage.xaml.cs`), criamos uma variável privada `_evento` do tipo `Evento` e a associamos ao `BindingContext` do componente no construtor:
```csharp
private Evento _evento;

public CadastroPage()
{
    InitializeComponent();
    _evento = new Evento();
    BindingContext = _evento; // Associa a tela ao nosso campo de dados
}
```
No arquivo XAML, utilizei a sintaxe `{Binding Propriedade}` nos campos de entrada (`Entry` e `DatePicker`). Isso permite que os valores digitados pelo usuário sejam automaticamente guardados nas propriedades do objeto `Evento` sem a necessidade de capturá-los um a um manualmente por código (Code-Behind).

### 2. Lógica de Negócio e Cálculos na Model (`Evento.cs`)
Toda a inteligência e as regras de cálculo del aplicativo foram colocadas diretamente dentro da classe de modelo `Evento.cs` (na pasta `Models`), mantendo a separação de responsabilidades:
* **Duração do Evento (`TimeSpan`)**: Utilizei a subtração de duas estruturas `DateTime` (`DataTermino - DataInicio`) que retorna um `TimeSpan`. A propriedade `DuracaoDias` lê a quantidade de dias dessa diferença de forma segura.
* **Custo Total**: Uma propriedade somente leitura que multiplica a quantidade de participantes pelo custo unitário (`NumeroParticipantes * CustoPorParticipante`).

### 3. Navegação Segura e Passagem de Parâmetros
Quando o usuário clica em cadastrar, a página de cadastro valida se as informações são coerentes (por exemplo, se o nome não está vazio e se a data de término não é anterior à de início). Após a validação, o objeto `Evento` preenchido é enviado como um parâmetro de navegação através do Shell do MAUI:
```csharp
var parameters = new Dictionary<string, object>
{
    { "Evento", evento }
};
await Shell.Current.GoToAsync("ResumoPage", parameters);
```
Na página de resumo (`ResumoPage.xaml.cs`), implementei a interface `IQueryAttributable` para capturar esse objeto enviado e atribuí-lo diretamente ao `BindingContext` da nova tela, exibindo as informações formatadas de forma dinâmica.

---

## 💪 Pontos Fortes da Aplicação

* **Validações Robustas**: O sistema não permite que o usuário avance com campos obrigatórios vazios ou com dados incoerentes (como número de participantes negativo, custos negativos ou datas de término anteriores ao início).
* **Interface Moderna e Responsiva**: Utilizei o elemento `Frame` com cantos arredondados e sombras suaves para criar uma aparência de "cards" modernos. Também configurei espaçamentos e layouts proporcionais para que o aplicativo fique bem alinhado em celulares de diferentes tamanhos.
* **Suporte a Tema Escuro (Dark Mode)**: Usei a marcação `{AppThemeBinding}` nos componentes visuais. Com isso, o aplicativo se adapta automaticamente se o celular do usuário estiver configurado no modo escuro, mantendo a leitura confortável e as cores harmoniosas.
* **Código Altamente Comentado**: Preenchi os arquivos XAML e C# com comentários claros explicando o propósito de cada marcação e comando, o que ajuda muito no aprendizado e na manutenção do código.

---

## 📈 Pontos a Melhorar (Próximos Passos de Aprendizado)

Como estudante técnico e desenvolvedor júnior, consigo identificar oportunidades de evolução para tornar a aplicação ainda mais profissional em projetos futuros:

1. **Implementação do Padrão MVVM Completo**: Em vez de associar a View diretamente à Model e fazer a validação no Code-Behind, o ideal seria criar uma `CadastroViewModel` utilizando o pacote `CommunityToolkit.Mvvm`. Isso separaria ainda mais a interface gráfica da lógica de controle.
2. **Cálculos em Tempo Real**: Atualmente, os cálculos de custo total e dias só são exibidos na tela de resumo. Utilizando propriedades notificáveis (`INotifyPropertyChanged`), daria para mostrar esses cálculos dinamicamente na própria tela de cadastro conforme o usuário digita as informações.
3. **Persistência de Dados**: O aplicativo armazena as informações apenas na memória volátil. Uma excelente melhoria seria adicionar um banco de dados local leve (como o *SQLite*) para salvar os eventos cadastrados, permitindo criar uma terceira tela com o histórico de eventos anteriores.
4. **Exportação e Compartilhamento**: Adicionar um botão na tela de resumo para que o organizador possa exportar as informações em formato PDF ou compartilhar os custos calculados diretamente por e-mail ou WhatsApp usando os recursos nativos do dispositivo.

---

## 📸 Capturas de Tela (Funcionamento do Aplicativo)

Aqui estão as capturas de tela reais demonstrando a aplicação em funcionamento:

### 1. Tela de Cadastro de Eventos
![Tela de Cadastro](Tela%201%20-%20Aplica%C3%A7%C3%A3o%20funcionado%20.png)

### 2. Tela de Resumo de Custos e Duração
![Resumo do Evento](Tela%202%20-%20Aplica%C3%A7%C3%A3o%20feito%20os%20cadastro.png)

### 3. Aplicativo Sendo Executado
![Execução do Aplicativo](Tela%203%20-%20Aplica%C3%A7%C3%A3o%20sendo%20executada%20e%20funcionado.png)

### 4. Visão Geral do Código-Fonte no Visual Studio
![Visão Geral do Código](Tela%204%20-%20Vis%C3%A3o%20geral%20do%20codigo%20da%20aplica%C3%A7%C3%A3o%20.png)

---

## 🚀 Como Executar o Projeto

1. Certifique-se de ter o **SDK do .NET 9** e o **Visual Studio 2022** (com a carga de trabalho de desenvolvimento móvel em .NET instalada).
2. Baixe ou clone este repositório.
3. Abra o arquivo de solução (`Agenda 15 - Desenvolvimento de Sistemas II - Cadastro de Eventos.sln`) no Visual Studio.
4. Escolha o dispositivo de teste (pode ser o emulador de Android, iOS ou o próprio Windows Machine).
5. Compile e execute o projeto pressionando a tecla `F5`.

---

**Dev pelo Valdan Conceição França**