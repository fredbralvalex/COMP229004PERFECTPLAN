public class Branch
{
    private int venueHostId;
    private int branchId;
    private string label;
    private int addressId;

    public Branch(int branchId, int venueHostId, int addressId, string label)
    {
        this.branchId = branchId;
        this.venueHostId = venueHostId;
        this.addressId = addressId;
        this.label = label;
    }    
}