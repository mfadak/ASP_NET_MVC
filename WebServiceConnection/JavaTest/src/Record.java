public class Record {
    public void send(String ticket,double temp,double hum){
        String urlstr = "http://localhost:50208/Api/Record";
        String json = "{\"Temp\":"+temp+",\"Hum\":"+hum+"}";
        int length = json.length();
        try{
            URL url = new URL(urlstr);
            HttpURLConnection conn = (HttpURLConnection)url.openConnection(); 
            conn.setRequestMethod("POST"); 
            conn.setDoOutput(true);
            conn.setRequestProperty("Authorization", "bearer "+ticket); 
            conn.setRequestProperty("Content-Type", "application/json"); 
            conn.setConnectTimeout(5000);
            conn.setReadTimeout(5000);
            HttpURLConnection.setFollowRedirects(true); 
            conn.setInstanceFollowRedirects(false); 
            conn.setDoOutput(true); 
            OutputStream os = conn.getOutputStream();
            os.write(json.getBytes());
            InputStream ip = conn.getInputStream(); 
            BufferedReader br1 = new BufferedReader(new InputStreamReader(ip));
            os.flush(); 
            System.out.println(conn.getResponseCode());
        }
        catch(JsonProcessingException ex){
            System.out.println(ex);
        }
        catch(IOException ex){
            System.out.println(ex);
        } 
    }
}
