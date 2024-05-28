package;

import flixel.FlxG;
import flixel.FlxSprite;
import flixel.FlxState;
import flixel.group.FlxGroup.FlxTypedGroup;
import flixel.group.FlxSpriteGroup.FlxTypedSpriteGroup;
import flixel.text.FlxText;
import flixel.ui.FlxButton;
import flixel.math.FlxMath;
import flixel.util.FlxColor;
import flixel.util.FlxSpriteUtil;
import flixel.FlxObject;
import flixel.animation.FlxAnimation;
import flixel.animation.FlxAnimationController;
import flixel.tweens.FlxTween;
import flixel.util.FlxTimer;
import haxe.Timer;
import flixel.util.FlxTimer;



class PlayState extends FlxState
{
	var paddle:FlxSprite = null;
	var ball:FlxSprite = null;
	var BALL_SPEED:Float = 200;
	var leftWall:FlxSprite = null;
	var rightWall:FlxSprite = null;
	var topWall:FlxSprite = null;
	var botmWall:FlxSprite = null;
	var grpWalls:FlxTypedGroup<FlxSprite> = null;
	var grpBricks:FlxTypedGroup<FlxSprite> = null;
	//var BallHitBrick:Bool = false;
	var PADDLE_SPEED:Float = 360;
	var BRICK_SPEED:Float = 50;
	var BrickSprite = AssetPaths.brick__png;
	var PaddleSprite = AssetPaths.paddle__png;
	var DbgrZoneG:FlxSprite;
	var DbgrZone:FlxAnimation;
	private var PADDLE_HEALTH = 100;
	var b_health = 100;
	var Brick_alpha = 255;
	var Player_red = 0;
	private var Player_HEALTH:FlxText;
	private var HealthScore = 0;
	private var HealthScore_TEXT:FlxText;
	var Brick_dead = 0;
	var WolvHUGS = 0;
	var Bricks_count = 0;
	private var Bricks_count_TEXT:FlxText;
	private var WolvHUGS_TEXT:FlxText;
	private var Brick_dead_TEXT:FlxText;
	private var Lets:FlxText;
	private var GAME_OVER:FlxText;
	private var REstartBTN:FlxButton;
	private var txtScore:FlxText;
	private var TimerTX:FlxTimer;
	private var TimeTX:Int = 15;
	private var ticks:Int = 0;
	private var txtTimerEND:FlxText;
	private var text:FlxText;
private var txtTime:FlxText;

	
	
	override public function create():Void
	{
		paddle = new FlxSprite(0, 0, PaddleSprite);
		
		//paddle.setGraphicSize( 0, 100);
		//paddle.offset(-10, -20);
		paddle.setPosition(FlxG.width / 2 - paddle.graphic.width / 2, FlxG.height - paddle.graphic.height + paddle.graphic.height / 3.3);
		//paddle.setSize( 100, 100 );
		paddle.immovable = true;
		paddle.setGraphicSize( 0, 90);
		paddle.elasticity = 0;
		
		ball = new FlxSprite(0, 0, "assets/images/Wolv.png");
		ball.setPosition(FlxG.width / 2 - ball.graphic.width / 2, FlxG.height / 2 - ball.graphic.height + ball.graphic.height / 3.3);
		//ball.makeGraphic(16, 16, FlxColor.RED);
		ball.screenCenter();
		add(ball);
		ball.velocity.set(BALL_SPEED, -BALL_SPEED);
		ball.elasticity = 1;
	
		
		//add walls
		grpWalls = new FlxTypedGroup<FlxSprite>();
		var topWall = new FlxSprite(0, 0);
		topWall.makeGraphic(FlxG.width, 8, FlxColor.RED);
		topWall.setPosition(0, 0);
		topWall.immovable = true;
		grpWalls.add(topWall);
		
		
				
		var botmWall = new FlxSprite( 0, FlxG.height - 20);
		botmWall.makeGraphic( FlxG.width, 8, FlxColor.RED );
		botmWall.setPosition( 0, FlxG.height - 20);
		botmWall.immovable = true;
		grpWalls.add(botmWall);
		
		
		var leftWall = new FlxSprite( 0, 0 );
		leftWall.makeGraphic( 8, FlxG.height, FlxColor.RED );
		leftWall.setPosition(0, 0);
		leftWall.immovable = true;
		grpWalls.add(leftWall);
		
		var rightWall = new FlxSprite( FlxG.width - 8, 0 );
		rightWall.makeGraphic( 8, FlxG.height, FlxColor.RED );
		rightWall.setPosition( FlxG.width - 8, 0 );
		rightWall.immovable = true;
		grpWalls.add(rightWall);
		for (wall in grpWalls)
		{
			wall.immovable == true;
		}
		add(grpWalls);
		
		//Bricks
		grpBricks = new FlxTypedGroup<FlxSprite>();
		for (row in 0...4)
		{
			for (col in 0...8)
			{
				//var b = new FlxSprite(80 - col * 80, 64 + row * 32, AssetPaths.brick__png);
				var b = new FlxSprite( FlxG.width / 1.5 - col * 80, 64 + row * 32, BrickSprite);
				
				b.setSize( 100, 100);
				b.setGraphicSize( 0, 38);
				//b.immovable = true;
				//b.color = 0xffea006e;
		b.elasticity = 1;
		Bricks_count = Bricks_count + 1; 
		
		
		var b_health = 100;
		
		if (b_health <= 0)
		{
			b.kill();
			Bricks_count = Bricks_count - 1; 
			Brick_dead = Brick_dead + 1;
		
			
			Brick_dead_TEXT.text = "DEAD words: " + Brick_dead;
		Bricks_count_TEXT.text = "Bricks: " + Bricks_count;
		}
		FlxSpriteUtil.bound(b, 55, FlxG.width - 55, 55, FlxG.height - 55);
		
				grpBricks.add(b);
				
		FlxSpriteUtil.bound(b, 55, FlxG.width - 55, 55, FlxG.height - 55);
			}
		}
		add(grpBricks);
		//grpBricks.setPosition(FlxG.width / 2 , FlxG.height / 2 - FlxG.height);
		Player_HEALTH = new FlxText(FlxG.width / 2 , FlxG.height / 2, 400, "HEALTH: " + PADDLE_HEALTH);
		Player_HEALTH.setFormat(null, 66, FlxColor.WHITE, CENTER);
		
		HealthScore_TEXT = new FlxText(FlxG.width / 2 - 290, FlxG.height / 2 - 100, 400, "HEALTH-score: " + HealthScore);
		HealthScore_TEXT.setFormat(null, 26, FlxColor.WHITE, CENTER);
		Brick_dead_TEXT  = new FlxText(FlxG.width / 2 - 290 , FlxG.height / 2 - 50, 400, "DEAD words: " + Brick_dead);
		Brick_dead_TEXT.setFormat(null, 26, FlxColor.WHITE, CENTER);
		WolvHUGS_TEXT = new FlxText(FlxG.width / 2 - 290, FlxG.height / 2 - 150, 400, "WolverineHUG: " + WolvHUGS);
		WolvHUGS_TEXT.setFormat(null, 26, FlxColor.WHITE, CENTER);
		Bricks_count_TEXT = new FlxText(FlxG.width / 2 - 290, FlxG.height / 2 - 250, 400, "Bricks: " + Bricks_count);
		Bricks_count_TEXT.setFormat(null, 26, FlxColor.WHITE, CENTER);
		//DbgrZoneG.loadGraphic("assets/images/dngr_zone.png", true, 87, 81);
		//DbgrZoneG.setPosition(FlxG.width / 2 , FlxG.height / 2);		
	//DbgrZoneG.animation.add("r", [0, 1, 0, 2], 14, true);
//add(DbgrZoneG);
		


		Lets = new FlxText(FlxG.width / 2, (FlxG.height / 2)-170, 400, "Let's HUG before You DIE!!! ");
		Lets.setFormat(null, 48, FlxColor.PINK, CENTER);
				GAME_OVER = new FlxText((FlxG.width / 2)-370 , (FlxG.height / 2)+200, 800, "GAME_OVER ");
		GAME_OVER.setFormat(null, 78, FlxColor.RED, CENTER);
		
		REstartBTN = new FlxButton(355, 405, "RESTART", clckREStart);
		REstartBTN.color = new FlxColor(0xffffff);
		REstartBTN.scale.x = REstartBTN.scale.y = 4;

		
		
		TimerTX = new FlxTimer();
		TimerTX.start(1, onTimeEnd, TimeTX);

		
		
		 txtScore = new FlxText(20, 40, 260, "", 14);
		super.create();
		
		
	}
	

					private function onTimeEnd(timer:FlxTimer):Void {
		ticks++;
		
		
		 txtScore.text = "Time: " + ticks;

		
txtScore.setFormat(null, 16, FlxColor.RED, CENTER);


txtScore.text;
			txtScore.setPosition(20, 20);
txtScore.setSize(66, 155);


if (ticks >= TimeTX){
			var txtTimerEND = new FlxText(20, 40, 260, "Time END", 34); 
		txtScore.setSize(466, 255);
			add(txtTimerEND);
		}
	}
/**
		function DbgrZn()
{
	
	DbgrZoneG.animation.play("r");
}
	
**/
			function BallHitBrick(Ball:FlxSprite, Brick:FlxSprite)
	{
		//Brick.velocity.set(BRICK_SPEED, -BRICK_SPEED);
		//BallHitBrick = true;
		//Brick.kill();
		//Ball.velocity.set( -BALL_SPEED, BALL_SPEED);
		//DbgrZn();
		var ballMid:Int = Std.int(Ball.x + Ball.width / 2);
	var brickMid:Int = Std.int(Brick.x + Brick.width / 2);
		
	b_health = b_health + 30;
		
		Player_health_show();	
		if (ballMid < brickMid)
		{
			Ball.velocity.x = -BALL_SPEED;
			Brick.velocity.x = BRICK_SPEED;
			
		Brick_alpha = Brick_alpha + 50;
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
		
		Brick.scale.x =  Brick.scale.x + 9 / 1000;
		Brick.scale.y = Brick.scale.y + 9 / 1000;
		if (Brick.scale.y >= 2)
		{
		Brick.scale.x = Brick.scale.y = 1;
		}
		}
		else if (ballMid > brickMid)
		{
			
		Brick.scale.x =  Brick.scale.x + 8 / 1000;
		Brick.scale.y = Brick.scale.y + 8 / 1000;
		if (Brick.scale.y >= 2)
		{
		Brick.scale.x = Brick.scale.y = 1;
		}
		Brick_alpha = Brick_alpha + 90;
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
			Ball.velocity.x = BALL_SPEED;
			Brick.velocity.x = BRICK_SPEED;
		}
		else
		{
			
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
		Brick.scale.x = Brick.scale.y = 0;
		Ball.velocity.x = 0;	  
		Brick.velocity.x = 0;
		}
		
		
	}

function BrickHitWALL(Brick:FlxSprite, grpWalls)
	{
		//Brick.velocity.set(-BRICK_SPEED, BRICK_SPEED);
		//Brick.kill();
		//BallHitBrick = false;
		b_health = b_health - 3;
		
		PADDLE_HEALTH = PADDLE_HEALTH + 1;
		Player_HEALTH.text = "HEALTH: " + PADDLE_HEALTH;
		
		Brick_alpha = Brick_alpha - 5;
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
		if ( b_health <= 0)
		{
			Brick_alpha = Brick_alpha - 100;
		Player_health_show();
			Brick.kill();
			Brick_dead = Brick_dead + 1;
			Brick_dead_TEXT.text = "DEAD words: " + Brick_dead;
		Bricks_count = Bricks_count - 1; 
			PADDLE_HEALTH = PADDLE_HEALTH + 10;
		Player_HEALTH.text = "HEALTH: " + PADDLE_HEALTH;
		
			Player_red = Player_red + 10;
			paddle.color = FlxColor.fromRGB(255, Player_red, Player_red, 255);
		}
		
	}

	function hitBall(Ball:FlxSprite, Paddle:FlxSprite)
	{
		WolvHUGS = WolvHUGS + 1;
		WolvHUGS_TEXT.text = "WolverineHUG: " + WolvHUGS;
		Player_health_show();
	var ballMid:Int = Std.int(Ball.x + Ball.width / 2);
	var paddleMid:Int = Std.int(Paddle.x + Paddle.width / 2);
		PADDLE_HEALTH = PADDLE_HEALTH - 5;
		Player_HEALTH.text = "HEALTH: " + PADDLE_HEALTH;
		
		if (ballMid < paddleMid)
		{
			Ball.velocity.x = -BALL_SPEED;
			Player_red = Player_red - 20;
			paddle.color = FlxColor.fromRGB(255, Player_red, Player_red, 255);
		}
		else if (ballMid > paddleMid)
		{
			Ball.velocity.x = BALL_SPEED;
			Player_red = Player_red - 30;
			paddle.color = FlxColor.fromRGB(255, Player_red, Player_red, 255);
		}
		else
		{
		Ball.velocity.x = 0;	
		
		paddle.color = FlxColor.WHITE;
		}
	}
	
	function PaddleHitBrick(Paddle:FlxSprite, Brick:FlxSprite)
	{
		
		Player_health_show();
	var brickMid:Int = Std.int(Brick.x + Brick.width / 2);
	var paddleMid:Int = Std.int(Paddle.x + Paddle.width / 2);
		b_health = b_health - 1;
		
	
		if (brickMid < paddleMid)
		{
			Brick.color.red;
			Brick.velocity.x = -BRICK_SPEED;
		Brick_alpha = Brick_alpha - 40;
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
		}
		else if (brickMid > paddleMid)
		{
		Brick_alpha = Brick_alpha - 30;
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
			Brick.velocity.x = BRICK_SPEED;
		}
		else
		{
			
		Brick.velocity.x = 0;
		Brick_alpha = Brick_alpha - 20;
Brick.color = FlxColor.fromRGB(Brick_alpha, Brick_alpha, Brick_alpha, Brick_alpha);
if (Brick_alpha <= 40)
{
	Brick_alpha = 100;
}
//Brick.color = FlxColor.fromRGB(255, 255, 255, Brick_alpha);
		}
		
		if ( b_health <= 0)
		{
			Brick.kill();
			Brick_dead = Brick_dead + 1;
			Brick_dead_TEXT.text = "DEAD words: " + Brick_dead;
			
		Bricks_count = Bricks_count - 1; 
		Bricks_count_TEXT.text = "Bricks: " + Bricks_count;
			PADDLE_HEALTH = PADDLE_HEALTH + 10;
		Player_HEALTH.text = "HEALTH: " + PADDLE_HEALTH;
		
			Player_red = Player_red + 20;
			paddle.color = FlxColor.fromRGB(255, Player_red, Player_red, 255);
		}
		
	}
	
	function Player_health_show()
	{
		if (PADDLE_HEALTH <= 30)
		{
		//PaddleSprite = AssetPaths.paddle_dmg__png;
		//paddle.color = FlxColor.WHITE;

		
		add(Lets);
		
		}
		if (PADDLE_HEALTH >= 100)
		{
			HealthScore = HealthScore + PADDLE_HEALTH - 100;
			HealthScore_TEXT.text = "HEALTH-score: " + HealthScore;
			PADDLE_HEALTH = 100;
		}
				if (PADDLE_HEALTH <= 0)
		{
		
		//PaddleSprite = AssetPaths.paddle_dmg__png;
		//paddle.color = FlxColor.WHITE;
		//**

		add(GAME_OVER);
		paddle.kill();
		add(REstartBTN);
		
		//**/
		}
		else
		{
			PaddleSprite = AssetPaths.paddle__png;
			paddle.color = FlxColor.fromRGB(255, Player_red, Player_red, 255);
		}
		if (PADDLE_HEALTH >= 80)
		{
		paddle.color = FlxColor.WHITE;
		}
		
		add(paddle);
	}
	
	
		function clckREStart()
		{
	
		FlxG.cameras.fade(FlxColor.RED, 1, false, FadeRestart);
		}
		function FadeRestart()
		{
		FlxG.switchState(new PlayState());
		}
	override public function update(elapsed:Float):Void
	{
		
		
		super.update(elapsed);
		//Paddle control
		if (FlxG.keys.pressed.LEFT)
		{
			
			paddle.facing = FlxObject.LEFT;
		Player_health_show();
			paddle.velocity.x = -PADDLE_SPEED;
			paddle.angle = 0;
//paddle.flipX = true;
if (paddle.flipY == true )
{

			
			paddle.angle = 90;
}

else
			paddle.angle = -90;
			
		}
		else if (FlxG.keys.pressed.RIGHT)
		{
			paddle.velocity.x = PADDLE_SPEED;
			paddle.facing = FlxObject.RIGHT;
			
paddle.angle = 0;
			
//paddle.flipX = false;
if (paddle.flipY == true )
{

			paddle.angle = -90;
}


else
			paddle.angle = 90;
		Player_health_show();
		}
		else{
			paddle.velocity.x = 0;
		}
				if (FlxG.keys.pressed.UP)
						{
			
			paddle.angle = 0;
			paddle.facing = FlxObject.UP;
		Player_health_show();
//paddle.flipY = false;
			paddle.velocity.y = -PADDLE_SPEED;
		}
		else if (FlxG.keys.pressed.DOWN)
		{
			
			paddle.angle = 0;
			paddle.angle = -180;
			paddle.facing = FlxObject.DOWN;
		Player_health_show();
//paddle.flipY = true;
			paddle.velocity.y = PADDLE_SPEED;
		}
		else{
			paddle.velocity.y = 0;
		}
		                              // Left, Top, Right,B 
		FlxSpriteUtil.bound(paddle, -100, FlxG.width +120, -70, FlxG.height + 60);
		FlxSpriteUtil.bound(ball, 55, FlxG.width - 55, 55, FlxG.height - 55);
		
		//FlxSpriteUtil.bound(leftWall);
		//FlxSpriteUtil.bound(rightWall);
		//FlxSpriteUtil.bound(topWall);
		//FlxSpriteUtil.bound(botmWall);
		
		
		FlxG.collide(ball, grpWalls);
		
		//FlxG.collide(ball, grpWalls);

		FlxG.collide(ball, grpBricks, BallHitBrick);
		
		FlxG.collide(grpBricks, grpWalls, BrickHitWALL);
		
		FlxG.collide(ball, paddle, hitBall);
		
		FlxG.collide(paddle, grpBricks, PaddleHitBrick);
		
		add(Player_HEALTH);
		add(HealthScore_TEXT);
		add(Brick_dead_TEXT);
		add(WolvHUGS_TEXT);
		add(Bricks_count_TEXT);
		
add(txtScore);
		Player_health_show();
		
		/**
		if (BallHitBrick == true)
		{
		FlxG.collide(grpBricks, rightWall, BrickHitWALL);
		}
		**/
	}
}
