import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random randomGenerator;
	private Point point;
	private Color appleColor;
	
	public Apple(Snake snake) {
		point = createApple(snake);
		cvetaNaZmiat1 = Color.RED;		
	}
	
	public Point getPoint(){
		return this.point;
	}
	
	private Point createApple(Snake snake) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (Point snakePoint : snake.zmiiskoTqlo) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(snake);				
			}
		}
		return new Point(x, y);
	}
	
	public void drawApple(Graphics g){
		point.paintPoint(g, this.appleColor);
	}	
}
