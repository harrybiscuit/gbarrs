<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="CassiniExplorer._Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cassini ASP.NET Server Applications</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="Main.css" rel="stylesheet">
			<script language="JavaScript" type="text/JavaScript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
			</script>
			
		<script language=javascript>
			// Update app status every few seconds
			
			var delayBetweenStatusCalls = 30000; // milliseconds
			
			// returns ref to span element for given app ID
			function GetStatusControlByAppID(appID)
			{
				var count = statusControlIDs.length;
				for(var i = 0 ; i < count ; i++)
				{
					var control = document.getElementById(statusControlIDs[i]);
					if(control != null)
					{
						var appIDAttribValue = control.getAttribute("AppID");
						if(appIDAttribValue != null && appIDAttribValue == appID)
						{
							return control;
						}
					}
				}
			}

			// Ajax func that goes to server and brings app status collection
			function CheckAppStatus()
			{
				window.status = "Updating Application Status. Pleas wait...";
				try
				{
					var appsStatus = CassiniExplorer._Default.GetAppsStatus().value;
					if(appsStatus == null)
						return;

					for(var i = 0 ; i < appsStatus.length ; i++)
					{
						var appInfo = appsStatus[i];

						var statusControl = GetStatusControlByAppID(appInfo.appID);
						if(statusControl != null)
						{
							if(appInfo.isRunning)
								statusControl.innerHTML = 'Running';
							else
								statusControl.innerHTML = 'Not Running';
						}
					}
				}
				catch(er)
				{
				}
				window.status = "";
				
				window.setTimeout('CheckAppStatus();', delayBetweenStatusCalls);
			}
		</script>
	</HEAD>
	<body bgColor="#e1e1e1" leftMargin="0" topMargin="0" onload="MM_preloadImages('images/register-main-over.gif','images/about-main-over.gif','images/ultidev-main-over.gif','images/register2-2.gif','images/about2-1.gif','images/about1-2.gif','images/ultidev2.gif')"
		marginheight="0" marginwidth="0" MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="800" align="center" border="0">
				<tr>
					<td vAlign="top" align="left" height="16"><IMG height="16" src="images/top.gif" width="800"></td>
				</tr>
				<tr>
					<td vAlign="top" align="left"><a href="http://www.ultidev.com" target="_blank"><IMG height="58" src="images/banner.gif" width="800" border="0"></a></td>
				</tr>
				<tr>
					<td vAlign="top" align="left">
						<table cellSpacing="0" cellPadding="0" width="800" border="0">
							<tr vAlign="top" align="left">
								<td width="252"><a href="http://www.ultidev.com" target="_blank"><IMG height="31" src="images/logo-text.gif" width="252" border="0"></a></td>
								<td width="36"><IMG id="registerleft" height="31" src="images/register1.gif" width="36" name="registerleft"></td>
								<td width="144"><A href="ApplicationDetails.aspx"><IMG onmouseover="MM_swapImage('registerleft','','images/register2.gif', 'register','','images/register-main-over.gif','registerside','','images/register2-1.gif',1)"
											onmouseout="MM_swapImgRestore()" height="31" src="images/register-main.gif" width="144" border="0" name="register"></A></td>
								<td width="36"><IMG id="registerside" height="31" src="images/register1-1.gif" width="36" name="registerside"></td>
								<td width="135"><a href="http://www.ultidev.com/products/Cassini/" target="_blank"><IMG onmouseover="MM_swapImage('registerside','','images/register1-2.gif','about','','images/about-main-over.gif','aboutside','','images/about2-1.gif',1)"
											onmouseout="MM_swapImgRestore()" height="31" src="images/about-main.gif" width="135" border="0" name="about"></a></td>
								<td width="36"><IMG id="aboutside" height="31" src="images/about1-1.gif" width="36" name="aboutside"></td>
								<td width="135"><a href="http://www.ultidev.com" target="_blank"><IMG onmouseover="MM_swapImage('aboutside','','images/about1-2.gif','ultidev','','images/ultidev-main-over.gif','ultidecside','','images/ultidev2.gif',1)"
											onmouseout="MM_swapImgRestore()" height="31" src="images/ultidev-main.gif" width="135" border="0" name="ultidev"></a></td>
								<td><IMG id="ultidecside" height="31" src="images/ultidev1.gif" width="26" name="ultidecside"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" align="left"><IMG height="21" src="images/middle.gif" width="800"></td>
				</tr>
				<tr>
					<td vAlign="top" align="left">
						<table cellSpacing="0" cellPadding="0" width="800" border="0">
							<tr vAlign="top" align="left">
								<td width="18"><IMG height="261" src="images/left.gif" width="18"></td>
								<td width="756" bgColor="#ffffff">
									<table cellSpacing="0" cellPadding="0" width="756" border="0">
										<TR>
											<TD width="28" height="50"></TD>
											<TD width="700" bgColor="whitesmoke" valign="middle">
												<H2 align="right" height="50">
													Registered Applications&nbsp;&nbsp;
												</H2>
											</TD>
											<TD width="28" height="50"></TD>
										</TR>
										<tr vAlign="top" align="left">
											<td width="28"><IMG height="1" src="images/pix.gif" width="28"></td>
											<td align="center" width="700"><asp:datagrid id=DataGrid1 runat="server" BorderWidth="0px" CellSpacing="1" CellPadding="3" CssClass="ApplicationGrid" AutoGenerateColumns="False" DataKeyField="ApplicationID" DataMember="CassiniApplications" DataSource="<%# applicationsDataSet %>" Width="100%" BackColor="White" BorderColor="White">
													<SelectedItemStyle Wrap="False"></SelectedItemStyle>
													<AlternatingItemStyle Font-Size="Smaller" Wrap="False" BackColor="WhiteSmoke"></AlternatingItemStyle>
													<ItemStyle Font-Size="Smaller" Wrap="False" BackColor="SeaShell"></ItemStyle>
													<HeaderStyle Font-Bold="True" Wrap="False" HorizontalAlign="Center" BackColor="#E0E0E0"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id=HyperLink1 runat="server" NavigateUrl='<%# "ApplicationDetails.aspx?AppID=" + DataBinder.Eval(Container, "DataItem.ApplicationID").ToString() %>' DESIGNTIMEDRAGDROP="372" ToolTip="Edit application details" ImageUrl="images/buttons/edit.gif">
																</asp:HyperLink><IMG src="images/buttons/edit-unreg-space.gif"><asp:ImageButton id=deleteAppImageButton runat="server" ToolTip="Remove application from Cassini server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.ApplicationID") %>' CommandName="DeleteApplication" ImageUrl="images/buttons/unregister.gif">
																</asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="ApplicationID" SortExpression="ApplicationID" HeaderText="ApplicationID">
															<HeaderStyle Font-Bold="True"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Application">
															<ItemTemplate>
																<asp:HyperLink id=AppHyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.MachineNameURL") %>' Text='<%# DataBinder.Eval(Container, "DataItem.FriendlyName") %>' ToolTip='<%# GetAppTooltip(DataBinder.Eval(Container, "DataItem.Description")) %>' Target="_blank">
																</asp:HyperLink>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id=TextBox1 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FriendlyName") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Status">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:Label id=statusLabel runat="server" Text='<%# GetAppStatus(DataBinder.Eval(Container, "DataItem.IsRunning")) %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id=TextBox3 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IsRunning") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Port" SortExpression="Port" HeaderText="Port Number">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Physical Path">
															<ItemStyle Font-Names="Arial Narrow"></ItemStyle>
															<ItemTemplate>
																<asp:Label id=Label1 runat="server" Text='<%# GetDisplayPath(DataBinder.Eval(Container, "DataItem.PhysicalPath")) %>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.PhysicalPath") %>'>
																</asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox id=TextBox2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PhysicalPath") %>'>
																</asp:TextBox>
															</EditItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:datagrid></td>
											<td width="28"><IMG height="1" src="images/pix.gif" width="28"></td>
										</tr>
									</table>
								</td>
								<td width="26" background="images/right.gif"><IMG height="261" src="images/right.gif" width="26"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" align="left"><IMG height="49" src="images/bottom.gif" width="800"></td>
				</tr>
				<tr>
					<td vAlign="top" align="left">
						<table cellSpacing="0" cellPadding="0" width="800" border="0">
							<tr vAlign="top" align="left">
								<td width="48"><IMG height="1" src="images/pix.gif" width="60"></td>
								<td align="right" width="680">
									<div class="footer">
										© UltiDev LLC, All rights reserved. Using&nbsp;this software constitutes 
										accpetance of <A href="Cassini EULA.rtf">License Agrrement</A> terms. <A href="../terms.htm">
											<br>
										</A>
									</div>
								</td>
								<td width="61"><IMG height="1" src="images/pix.gif" width="60"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	<script language=javascript>
		window.setTimeout('CheckAppStatus();', 30000);
	</script>
	</body>
</HTML>
