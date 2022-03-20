<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="UTF-8">
	<title>Document</title>
</head>
<body>
	<form name="form1" method="post" action="confirm.php">
	<table border="2">
		<tr>
			<td>商品名稱</td>
			<td><input type="text" name="obj" size="30" readonly value="<?php echo $_POST['obj']?>"></td>
		</tr>
		<tr>
			<td>卡號</td>
			<td><input type="password" name="password" readonly value="<?php echo $_POST['password']; ?>"> </td>
		</tr>
		<tr>
			<td>聯絡信箱</td>
			<td><input type="email" name="email" readonly value="<?php echo $_POST['email']?>"></td>
		</tr>
		<tr>
			<td>計件日期</td>
			<td><input type="date" name="data" readonly value="<?php echo $_POST['data']?>"></td>
		</tr>	
		<tr>
			<td>類組</td>
			<td>
				<?php
				switch ($_POST["radio"]) {
					case '1':
					$x="大型";
						break;
					case '2':
					$x="中型";
						break;
					case '3':
					$x="輕型";
						break;
				}
				echo $x;
				?>
			</td>
		</tr>	
		<tr>
			<td>繳費方式</td>
			<td>
				<?php
				if(isset($_POST['submit'])) {
    				$country = $_POST['datalist'];
   					 echo $country;
				}
				?>
			</td>
		</tr>	
		<tr>
			<td>幣別</td>
			<td>
				<?php
				foreach ($_POST["Usermoney"] as $value) {
					echo '<input type="checkbox" name="Usermoney[]" checked>'.$value;}
					?>
			</td>
		</tr>
		<tr>
			<td>性別</td>
			<td>
						<?php
				if(isset($_POST['submit'])) {
    				$country = $_POST['性別'];
   					 echo $country;
				}
				?>
			</td>
		</tr>
		<tr>
			<td>R</td>
			<td><?php
				if(isset($_POST['submit'])) {
    				$country = $_POST['range01'];
   					 echo $country;
				}
				?></td>
		</tr>
		<tr>
			<td>G</td>
			<td><?php
				if(isset($_POST['submit'])) {
    				$country = $_POST['range02'];
   					 echo $country;
				}
				?>
		</tr>
		<tr>
			<td>B</td>
			<td><?php
				if(isset($_POST['submit'])) {
    				$country = $_POST['range03'];
   					 echo $country;
				}
				?></td>
		</tr>
		<tr>
			<td colspan="2" style="text-align: right;">
				<input type="button" name="back" onclick="history.back()" value="回表單">
			</td>
		</tr>
		</table>
	</form>
	<script>
		document.getElementById("range01").onchange=function(){
		document.getElementById("show-range01").innerHTML=document.getElementById("range01").value;
		}

		var a=document.getElementById("range02");
		var b=document.getElementById("show-range02");
		a.addEventListener("change",function(){
			b.value=a.value;
		})

		var x=document.getElementById("bot");
		var y=document.getElementById("range03");
		var z=document.getElementById("show-range03");
		x.addEventListener("click",function(){
			z.value=y.value;
		})
	</script>
	<a href="index.html">回到首頁</a>
</body>
</html>