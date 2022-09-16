<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RockPaperScissorTest._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
      <section>
        <table class="choices">
          <tr>
            <th>YOU</th>
            <th></th>
            <th>COMPUTER</th>
          </tr>
          <tr>
            <td class="choices-item">
              <asp:Image ID="yourChoiceImage" runat="server" ImageUrl="~/Assets/question-mark.png" /></td>
            <td class="choices-item">&nbsp;VERSUS&nbsp;</td>
            <td class="choices-item">
              <asp:Image class="choices-image" ID="computerChoiceImage" runat="server" ImageUrl="~/Assets/question-mark.png" /></td>
          </tr>

        </table>
      </section>
      <hr />
      <section class="player-buttons">
        <asp:ImageButton class="player-button" ID="rockButton" runat="server" ImageUrl="~/Assets/rock.png" OnClick="rockButton_Click" />
        <asp:ImageButton class="player-button" ID="paperButton" runat="server" ImageUrl="~/Assets/paper.png" OnClick="paperButton_Click" />
        <asp:ImageButton class="player-button" ID="scissorsButton" runat="server" ImageUrl="~/Assets/scissors.png" OnClick="scissorsButton_Click" />
      </section>
      <section class="instructions">
        <p>To play, click one of the three buttons in dotted boxes above. The result of your game will be shown below. Good luck!</p>
      </section>
      <section class="results-text">
        <asp:Label ID="resultLabel" runat="server" Style="font-size: xx-large; text-align: center; color: #FF0000" Text="Result is...."></asp:Label>
      </section>
        <section>
            <table>
                <tr>
                    <th>
                        Player Option
                    </th>
                     <th>
                        Computer Option
                    </th>
                     <th>
                        Win/Lose/Draw
                    </th>

                 </tr>
                    <% foreach (var result in listResults) {  %>
                       <tr>
                            <td><%= result.PlayerOption %></td>
                             <td><%= result.BotOption %></td>
                             <td><%= result.Win %>/<%= result.Lose %>/<%= result.Draw %></td>
                                
                       </tr>
                    <% } %>
            </table>
        </section>
    
    </div>

</asp:Content>
