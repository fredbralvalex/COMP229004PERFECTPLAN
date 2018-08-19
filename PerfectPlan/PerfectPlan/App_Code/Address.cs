public class Address
{
    private int id;
    private string street;
    private int number;
    private string zipCode;
    private string city;
    private string province;
    private string country;

    public Address(int id, string street, int number, string zipCode, string city, string province, string country)
    {
        this.id = id;
        this.street = street;
        this.number = number;
        this.zipCode = zipCode;
        this.city = city;
        this.province = province;
        this.country = country;
    }
}