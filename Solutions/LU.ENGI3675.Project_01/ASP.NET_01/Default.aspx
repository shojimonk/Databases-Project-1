<%@ Page Language="C#" %>

<html>
<head>
    <title>Table 01
    </title>
</head>
<body>
   <table> 
       <tr>
           <td><b> Colour </b></td> 
           <td><b> Liters </b></td> 
       </tr>

       <%
               List <LU.ENGI3675.Databases1.Paints> paint = LU.ENGI3675.Databases1.DataIn.Import();
               
               foreach(LU.ENGI3675.Databases1.Paints temp in paint) 
               {
                   Response.Write("<tr>");
                   Response.Write(string.Format("<td>{0} </td> <td>{1}</td>", temp.colour,temp.amount));
                   Response.Write("</tr>");
               }

        %>

   </table>
</body>

</html>
