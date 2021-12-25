public class Ticket {
    private String token;
    public Ticket(){
        String urlpath = "http://localhost:50208/Bilet";
        BufferedReader read=null;
        HttpURLConnection conn = null;
        try{
            URL url = new URL(urlpath);
            OutputStream output = null;
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setDoOutput(true);
            conn.setDoInput(true);
            conn.setRequestProperty("Content-Type", "application/x-www-form-urlencoded");
            conn.setConnectTimeout(5000);
            conn.setReadTimeout(5000);
            String auth = "grant_type=password&username=dene@dene.com&password=As_1234";
            output = conn.getOutputStream();
            output.write(auth.getBytes());
            output.flush();
            if(conn.getResponseCode() != HttpURLConnection.HTTP_OK){
                System.err.println("Connection Error!");
                return;
            }
            InputStream is = conn.getInputStream();
            read = new BufferedReader(new InputStreamReader((is)));
            String tmpStr = null;
            while((tmpStr = read.readLine()) != null){
                ObjectMapper mapper = new ObjectMapper();
                JsonNode node = mapper.readTree(tmpStr);
                token = node.findValue("access_token").textValue();
            }
        }
        catch (MalformedURLException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (IOException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } finally {
            try {
                if(read != null) read.close();
                if(conn != null) conn.disconnect();               
            } catch(Exception ex){
                 
            }
        }
    }
    public String getToken(){
        return token;
    }
}
