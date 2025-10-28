namespace ApiRemedio;

public class RemedioEntidade{

    public int Id { get; set; }
    public string nomeRemedio { get; set; }
    public DateOnly dataValidade{ get; set; }
    public double valor { get; set; }
    public string marca { get; set; }
    public double miligramas { get; set; }



}