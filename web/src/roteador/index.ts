import { createRouter, createWebHashHistory, RouteRecordRaw } from "vue-router";

import Usuarios from '../views/Usuarios.vue'
import ListaUsuarios from '../views/Usuarios/ListaUsuarios.vue'
import FormUsuario from '../views/Usuarios/FormUsuario.vue'

const rotas: RouteRecordRaw[] = [
    {
        path: '/usuarios',
        component: Usuarios,
        children: [
            {
                path: '',
                name: 'Usuarios',
                component: ListaUsuarios
            },
            {
                path: 'novo',
                name: 'Novo projeto',
                component: FormUsuario
            },
            {
                path: ':id',
                name: 'Editar projeto',
                component: FormUsuario,
                props: true
            },
        ]
    }
]


const roteador = createRouter({
    history: createWebHashHistory(),
    routes: rotas
})

export default roteador;