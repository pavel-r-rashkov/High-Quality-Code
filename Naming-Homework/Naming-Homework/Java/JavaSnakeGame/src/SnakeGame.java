import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")
public class SnakeGame extends Canvas implements Runnable {
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension gameSize = new Dimension(this.WIDTH, this.HEIGHT);
	
	public static Snake snake;
	public static Apple apple;
	static int points;
	
	private Graphics globalGraphics;
	private Thread runThread;
	
	static boolean gameRunning = false;
	
	public void paint(Graphics g){
		this.setPreferredSize(this.gameSize);
		globalGraphics = g.create();
		points = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: Handle exception
			}
		}
	}
	
	public SnakeGame(){	
		this.snake = new Snake();
		this.apple = new Apple(snake);
	}
		
	public void render(Graphics g){
		g.clearRect(0, 0, this.WIDTH, this.HEIGHT + 25);
		
		g.drawRect(0, 0, this.WIDTH, this.HEIGHT);			
		snake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + this.points, 10, this.HEIGHT + 25);		
	}
}

