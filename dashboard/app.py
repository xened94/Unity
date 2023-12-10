from flask import Flask, render_template, request, redirect, url_for
from flask_sqlalchemy import SQLAlchemy
import plotly.express as px
from flask_migrate import Migrate
from datetime import datetime
import pandas as pd

app = Flask(__name__)
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///terapias.db'
db = SQLAlchemy(app)
migrate = Migrate(app, db)

class TreatmentData(db.Model):
    treatmentNumber = db.Column(db.Integer, primary_key=True)
    playerName = db.Column(db.String(50))
    date = db.Column(db.String(10))
    score = db.Column(db.Float)
    miniGameName = db.Column(db.String(50))
    level = db.Column(db.Integer)
    time = db.Column(db.Float)
    objectCount = db.Column(db.Integer)

# Nueva ruta para filtrar por nombre de jugador
@app.route('/player/<player_name>')
def player_dashboard(player_name):
    # Filtra los datos para el jugador específico
    player_data_entries = TreatmentData.query.filter_by(playerName=player_name).all()

    # Convertir el formato de fecha antes de generar el gráfico
    for entry in player_data_entries:
        entry.date = datetime.strptime(entry.date, '%y/%m/%d')

    # Convertir la lista de objetos a un DataFrame de Pandas
    df = pd.DataFrame([vars(entry) for entry in player_data_entries])

    # Generar gráficos específicos para el jugador
    if 'miniGameName' in df.columns:
        fig1 = px.bar(df, x='miniGameName', y='score', title=f'Puntaje vs MiniJuego para {player_name}', labels={'miniGameName': 'Juego', 'score': 'Puntaje'})
    else:
        fig1 = None

    if 'level' in df.columns:
        fig2 = px.bar(df, x='level', y='score', title=f'Tipo de mano vs Puntaje para {player_name}', labels={'level': 'Tipo de Mano', 'score': 'Puntaje'})
    else:
        fig2 = None

    # ... (otros gráficos según sea necesario)

    # Convertir los gráficos a HTML
    graph_html1 = fig1.to_html(full_html=False) if fig1 else None
    graph_html2 = fig2.to_html(full_html=False) if fig2 else None
    # ... (otros gráficos según sea necesario)

    # Definir otras variables necesarias
    if 'objectCount' in df.columns:
        fig3 = px.bar(df, x='objectCount', y='score', title=f'Grafico de objetos {player_name}', labels={'objectCount': 'Nombre de la columna', 'score': 'Puntaje'})
    else:
        fig3 = None

    if 'time' in df.columns:
        fig4 = px.bar(df, x='time', y='score', title=f'Grafico de tiempo {player_name}', labels={'time': 'Nombre de otra columna', 'score': 'Puntaje'})
    else:
        fig4 = None

    if 'date' in df.columns:
        fig5 = px.bar(df, x='date', y='score', title=f'Por Fecha{player_name}', labels={'date': 'Nombre de otra columna más', 'score': 'Puntaje'})
    else:
        fig5 = None

    # Convertir los gráficos a HTML
    graph_html3 = fig3.to_html(full_html=False) if fig3 else None
    graph_html4 = fig4.to_html(full_html=False) if fig4 else None
    graph_html5 = fig5.to_html(full_html=False) if fig5 else None

    return render_template('player_dashboard.html', player_name=player_name, graph_html1=graph_html1, graph_html2=graph_html2, graph_html3=graph_html3, graph_html4=graph_html4, graph_html5=graph_html5)

# Ruta para visualizar el dashboard
@app.route('/')
def dashboard():
    treatment_data_entries = TreatmentData.query.all()

    # Convertir el formato de fecha antes de generar el gráfico
    for entry in treatment_data_entries:
        entry.date = datetime.strptime(entry.date, '%y/%m/%d')

    # Convertir la lista de objetos a un DataFrame de Pandas
    df = pd.DataFrame([vars(entry) for entry in treatment_data_entries])

    # Generar múltiples gráficos con Plotly Express
    fig1 = px.bar(df, x='miniGameName', y='score', title='Puntaje vs MiniJuego', labels={'miniGameName': 'Juego', 'score': 'Puntaje'})
    fig2 = px.bar(df, x='level', y='score', title='Tipo de mano vs Puntaje', labels={'level': 'Tipo de Mano', 'score': 'Puntaje'})
    fig3 = px.area(df, x='level', y='objectCount', title='Tipo de mano vs Cantidad Objetos', labels={'level': 'Tipo de Mano', 'objectCount': 'Objetos'})
    fig4 = px.ecdf(df, x='date', y='score', title='Fecha vs Score', labels={'date': 'Fecha'})

    # Gráfico de pastel para mostrar la distribución de level para cada playerName
    fig5 = px.pie(df, names='playerName', title='Cantidad de Terapias', labels={'playerName': 'Nombre'})

    # Gráficos adicionales
    fig6 = px.histogram(df, x='time', color='level', marginal='rug', title='Distribución del Tiempo por Nivel', labels={'time': 'Tiempo'})
    graph_html6 = fig6.to_html(full_html=False)
    fig7 = px.scatter(df, x='score', y='objectCount', color='miniGameName', size='time', title='Puntaje vs Cantidad de Objetos', labels={'score': 'Puntaje', 'objectCount': 'Objetos'})
    graph_html7 = fig7.to_html(full_html=False)

    fig8 = px.pie(df, names='miniGameName', values='time', title='Tiempo por Minijuego')
    graph_html8 = fig8.to_html(full_html=False)

    fig9 = px.bar(df, x='miniGameName', y='objectCount', color='level', title='Objetos Colisionados por Minijuego', labels={'miniGameName': 'Juego', 'objectCount': 'Objetos'})
    graph_html9 = fig9.to_html(full_html=False)

    # Convertir los gráficos a HTML
    graph_html1 = fig1.to_html(full_html=False)
    graph_html2 = fig2.to_html(full_html=False)
    graph_html3 = fig3.to_html(full_html=False)
    graph_html4 = fig4.to_html(full_html=False)
    graph_html5 = fig5.to_html(full_html=False)

    # Imprimir las primeras filas del DataFrame
    print(df.head())

    return render_template('dashboard.html', graph_html1=graph_html1, graph_html2=graph_html2, graph_html3=graph_html3, graph_html4=graph_html4, graph_html5=graph_html5, graph_html6=graph_html6, graph_html7=graph_html7, graph_html8=graph_html8, graph_html9=graph_html9)

# Ruta para la búsqueda
@app.route('/search', methods=['GET', 'POST'])
def search():
    if request.method == 'POST':
        player_name = request.form['playerName']
        return redirect(url_for('player_dashboard', player_name=player_name))
    return render_template('search.html')

if __name__ == '__main__':
    app.run(debug=True)
