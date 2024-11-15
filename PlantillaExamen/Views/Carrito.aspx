﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="PlantillaExamen.Views.Carrito" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Producto</title>
    <style>
        /* Estilos generales */
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 20px;
        }

        .main-container {
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
            gap: 20px;
            max-width: 1200px;
            margin: auto;
        }

        .container, .welcome-container {
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 90%;
            max-width: 400px;
            margin: auto;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        label {
            font-weight: bold;
            color: #333;
        }

        input[type="text"], input[type="number"], input[type="file"] {
            width: 100%;
            padding: 8px;
            margin: 8px 0 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        button {
            width: 100%;
            padding: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            button:hover {
                background-color: #45a049;
            }

        /* Estilos para el GridView */
        .grid-container {
            margin-top: 20px;
            overflow-x: auto;
        }

            .grid-container table {
                width: 100%;
                border-collapse: collapse;
            }

            .grid-container th, .grid-container td {
                padding: 10px;
                border: 1px solid #ddd;
                text-align: center;
            }

            .grid-container img {
                max-width: 100px;
                max-height: 100px;
                width: auto;
                height: auto;
            }

        /* Responsive design */
        @media (max-width: 600px) {
            .container, .welcome-container {
                width: 100%;
                padding: 15px;
            }

            .grid-container img {
                max-width: 70px;
                max-height: 70px;
            }
        }

        .welcome-container {
            text-align: center;
        }

            .welcome-container h1 {
                margin-bottom: 10px;
                font-size: 2em;
                color: #007bff;
            }

            .welcome-container p {
                font-size: 1.2em;
            }

            .welcome-container a {
                display: inline-block;
                margin-top: 20px;
                padding: 10px 20px;
                background-color: #007bff;
                color: white;
                text-decoration: none;
                border-radius: 5px;
                transition: background-color 0.3s ease;
            }

                .welcome-container a:hover {
                    background-color: #0056b3;
                }
    </style>
</head>
<body>
    <div class="main-container">
        <form id="formAgregarProducto" runat="server" enctype="multipart/form-data" class="container">
            <div class="welcome-container">
                <h1>¡Bienvenido!</h1>
                <p>Hola,
                    <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></p>
                <a href="Logout.aspx">Cerrar Sesión</a>
            </div>
            <h2>Agregar Producto</h2>

            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Required="true" placeholder="Ingrese el nombre"></asp:TextBox>

            <label for="txtCantidad">Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" Required="true" placeholder="Ingrese la cantidad"></asp:TextBox>

            <label for="txtCosto">Costo:</label>
            <asp:TextBox ID="txtCosto" runat="server" TextMode="Number" Required="true" placeholder="Ingrese el costo"></asp:TextBox>

            <label for="fileImagen">Imagen:</label>
            <asp:FileUpload ID="fileImagen" runat="server" />

            <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" />

            <div class="grid-container">
                <!-- GridView para mostrar productos -->
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" SortExpression="Precio" DataFormatString="{0:C}" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <asp:Image ID="imgProducto" runat="server" CssClass="img-responsive" ImageUrl='<%#Eval("ImagenUrl")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
