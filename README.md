# AppMeuCombustivel

App que ajuda a decidir se compensa abastecer com etanol ou gasolina. Você informa os dois preços e ele aplica a famosa regra dos 70%.

## Pra que serve

No posto, a dúvida é sempre a mesma: "etanol ou gasolina?". Esse app resolve isso com a regra que todo motorista brasileiro conhece: o etanol só vale a pena quando custa até 70% do preço da gasolina, porque rende cerca de 70% da energia.

## Como funciona

1. O usuário digita o preço do **etanol** e da **gasolina** (em reais)
2. Toca em **Calcular**
3. O app compara: `preco_etanol > preco_gasolina * 0.7`?
   - Se **sim** → "Compensa gasolina"
   - Se **não** → "Compensa o etanol"
4. O resultado aparece num alerta modal

### Exemplo prático

Gasolina a R$ 6,00 e etanol a R$ 4,50:
- 70% de 6,00 = 4,20
- 4,50 > 4,20 → compensa gasolina

Gasolina a R$ 6,00 e etanol a R$ 3,80:
- 3,80 < 4,20 → compensa etanol

## Stack

- **.NET MAUI 10** com C# e XAML
- **Arquitetura:** code-behind simples, uma tela só
- **Navegação:** Shell com rota única

## Estrutura do projeto

```
AppMeuCombustivel/
├── AppMeuCombustivel.slnx
└── AppMeuCombustivel/
    ├── MainPage.xaml(.cs)     # UI + lógica da regra dos 70%
    ├── AppShell.xaml
    ├── MauiProgram.cs
    ├── App.xaml(.cs)          # Janela 350x700
    ├── Resources/
    └── Platforms/
```

Não tem Models, ViewModels, Services nem outras páginas. Tudo cabe em umas 15 linhas de lógica no `Button_Clicked`.

## Plataformas

| SO de build | O que compila |
|-------------|---------------|
| Linux | Android |
| macOS | Android, iOS, Mac Catalyst |
| Windows | Todas as plataformas MAUI |

App ID: `com.companyname.appmeucombustivel`

## Dependências

- `Microsoft.Maui.Controls`
- `Microsoft.Extensions.Logging.Debug`

## Como rodar

```bash
cd AppMeuCombustivel/AppMeuCombustivel
dotnet restore
dotnet build -f net10.0-android
dotnet build -t:Run -f net10.0-android
```

No Windows também roda direto no desktop:

```bash
dotnet build -t:Run -f net10.0-windows10.0.19041.0
```

Precisa do .NET 10 SDK com workload MAUI instalada.

## Observações

- Não valida entrada: campo vazio ou texto inválido quebra o app
- O parsing numérico depende da cultura do dispositivo (vírgula vs ponto pode dar problema)
- O `DisplayAlertAsync` é chamado sem `await` (funciona, mas não é o padrão ideal)
- O manifest do Android pede permissão de internet, mas o app não usa rede
- Textos fixos em português, sem internacionalização

## Ideias de evolução

Formatação de moeda brasileira (R$), histórico dos últimos preços consultados, busca de preços em postos via API, validação de campos antes de calcular.
