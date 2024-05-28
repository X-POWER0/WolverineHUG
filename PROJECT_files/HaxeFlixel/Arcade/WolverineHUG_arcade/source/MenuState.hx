package;

import flixel.FlxG;
import flixel.FlxSprite;
import flixel.FlxState;
import flixel.text.FlxText;
import flixel.ui.FlxButton;
import flixel.math.FlxMath;
import flixel.util.FlxColor;

class MenuState extends FlxState
{
	private var startBTN:FlxButton;
	
	private var gmTitle:FlxText;
	
	override public function create():Void
	{

		FlxG.mouse.visible = true;
		
		gmTitle = new FlxText(140, 90, 520, "Wolverine HUG (arcade)");
				gmTitle.setFormat(null, 56, FlxColor.PINK, CENTER);
				add(gmTitle);
		
		
		startBTN = new FlxButton(355, 405, "START", clckStart);
		startBTN.color = new FlxColor(0xffffff);
		startBTN.scale.x = startBTN.scale.y = 4;
		add(startBTN);
		// Some credit text
		add(new FlxText(700, 550, 140, "by X-POWER"));
		
		super.create();


	}
private function clckStart():Void
	{
		FlxG.cameras.fade(FlxColor.RED, 0.015, false, onFade);
	}
	
	private function onFade():Void
	{
		
		FlxG.switchState(new PlayState());
	}

	override public function update(elapsed:Float):Void
	{
		super.update(elapsed);
	}
}
