public class Test{
  public static void main(String[] args) {
        Ticket ticket = new Ticket();
        Record record = new Record();
        record.send(ticket.getToken(), 12, 50);
  }
}
