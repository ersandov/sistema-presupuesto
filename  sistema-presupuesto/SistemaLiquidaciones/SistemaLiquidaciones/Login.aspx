<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaLiquidaciones.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="Styles/EstiloLogin/animate-custom.css" rel="stylesheet" type="text/css" />
    <link href="Styles/EstiloLogin/demo.css" rel="stylesheet" type="text/css" />
    <link href="Styles/EstiloLogin/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
        <div style="width: 100%; height: 50px;">
        </div>
        <div id="container_demo">
            <!-- hidden anchor to stop jump http://www.css3create.com/Astuce-Empecher-le-scroll-avec-l-utilisation-de-target#wrap4  -->
            <a class="hiddenanchor" id="toregister"></a><a class="hiddenanchor" id="tologin">
            </a>
            <div id="wrapper">
                <div id="login" class="animate form">
                    <%--<form  action="mysuperscript.php" autocomplete="on"> --%>
                    <h1>
                        Log in</h1>
                    <p>
                        <label for="username" class="uname" data-icon="u">
                            Your username
                        </label>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <label for="password" class="youpasswd" data-icon="p">
                            Your password
                        </label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </p>
                    <%-- <p class="keeplogin"> 
									<input type="checkbox" name="loginkeeping" id="loginkeeping" value="loginkeeping" /> 
									<label for="loginkeeping">Keep me logged in</label>
								</p>--%>
                    <p class="login button">
                        <asp:Button ID="Button1" runat="server" Text="Login" onclick="Button1_Click" />
                        <%-- <input type="submit" value="Login" /> --%>
                    </p>
                    <p class="change_link">
                        <b>Bienvenido al Sistema de Liquidaciones</b>
                        <%--<a href="#toregister" class="to_register">Join us</a>--%>
                    </p>
                    <%--</form>--%>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
