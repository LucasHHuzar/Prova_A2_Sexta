namespace Andre.Models;

public class FolhaDePagamento 
{

    Funcionario funcionario = new Funcionario();

    public FolhaDePagamento() 
    { 

    }

    public FolhaDePagamento(string Id, double valor, int quantidade, int mes, int ano, double salarioBruto,
    double impostoIrrf, double impostoInss, double ImpostoFgts, double SalarioLiquido)
    {
        Id = funcionario.Id;
        valor = valor;
        quantidade = quantidade;
        mes = mes;
        ano = ano;
        salarioBruto = salarioBruto;
        ImpostoIrrf = impostoIrrf;
        ImpostoInss = impostoInss;
        ImpostoFgts = ImpostoFgts;
        SalarioLiquido = SalarioLiquido;     

    }


    public string? Id { get ; set; }
    public double Valor { get ; set; }
    public int quantidade { get ; set; }
    public int mes { get; set; }
    public int ano { get; set; }
    public double SalarioBruto { get; set; }
    public double ImpostoIrrf { get; set; }
    public double ImpostoInss { get; set; }
    public double ImpostoFgts { get; set; }
    public double SalarioLiquido { get; set; }

        double contaFgts = 0; 
        double contaIrrf = 0;
        double contaInss = 0;
    public double bruto(){
        return SalarioBruto = Valor * quantidade;
    }
    public double irrf(){
        

        if(SalarioBruto <= 1.903){
            return SalarioBruto;
        }else if(SalarioBruto >= 1.904 || SalarioBruto <= 2.826){
            contaIrrf = SalarioBruto * 0.075;
        }else if(SalarioBruto >= 2.827 || SalarioBruto <= 3.751){
            contaIrrf = SalarioBruto * 0.15;
        }else if(SalarioBruto >= 3.752 || SalarioBruto <= 4.664){
            contaIrrf = SalarioBruto * 0.225;
        }else if(SalarioBruto > 4.665){
            contaIrrf = SalarioBruto * 0.275;
        }

        return contaIrrf;
    }

    public double inss(){

        if(SalarioBruto <= 1.693){
            contaInss = SalarioBruto * 0.08;
        }else if(SalarioBruto >= 1.694 || SalarioBruto <= 2.822){
            contaInss = SalarioBruto * 0.09;
        }else if(SalarioBruto >= 2.823 || SalarioBruto <= 5.645){
            contaInss = SalarioBruto * 0.11;
        }else if(SalarioBruto > 5.646){
            contaInss = SalarioBruto - 621.03;
        }

        return contaInss;
    }

    public double fgts(){

        return contaFgts = SalarioBruto * 0.08;
    }



    public double liquido(){
        return SalarioLiquido = SalarioBruto - contaIrrf - contaInss - contaFgts;
    }


}

