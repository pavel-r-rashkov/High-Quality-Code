import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class InputHandler implements KeyListener {
	
	public InputHandler(SnakeGame game) {
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent e) {
		int keyCode = e.getKeyCode();
		
		if (keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) {
			if(SnakeGame.snake.getVelY() != 20) {
				SnakeGame.snake.setVelX(0);
				SnakeGame.snake.setVelY(-20);
			}
		}
		if (keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) {
			if(SnakeGame.snake.getVelY() != -20) {
				SnakeGame.snake.setVelX(0);
				SnakeGame.snake.setVelY(20);
			}
		}
		if (keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) {
			if(SnakeGame.snake.getVelX() != -20) {
				SnakeGame.snake.setVelX(20);
				SnakeGame.snake.setVelY(0);
			}
		}
		if (keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) {
			if(SnakeGame.snake.getVelX() != 20) {
				SnakeGame.snake.setVelX(-20);
				SnakeGame.snake.setVelY(0);
			}
		}
		//Other controls
		if (keyCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent e) {
	}
	
	public void keyTyped(KeyEvent e) {
		
	}
}
