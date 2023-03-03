import { createStore, Store, useStore as vuexUseStore } from "vuex";
import { InjectionKey } from 'vue'
import { LISTA_USUARIOS, NOTIFICAR } from "./tipo-mutacoes";
import { INotificacao } from "@/interfaces/INotificacao";
import IUsuario from "@/interfaces/IUsuario";
import axios from "axios";

interface Estado {
    usuarios: IUsuario[],
    notificacoes: INotificacao[]
}

const API_URL = "http://localhost:5000/api";

export const key: InjectionKey<Store<Estado>> = Symbol()

export const store = createStore<Estado>({
    state: {
        usuarios: [],
        notificacoes: []
    },

    getters: {
        allUsers: state => state.usuarios
    },

    actions: {
        async fetchUsers({ commit }) {
            try {
                await axios.get(`${API_URL}/users`)
                    .then((response) => {
                        commit(LISTA_USUARIOS, response.data)
                    })
            } catch (error) {
                console.log('fetch error ', error)
            }
        },

        async deleteUser({ commit }, id) {
            await axios.delete(`${API_URL}/users/${id}`)
                .then((response) => {
                    console.log(response.data)
                    store.dispatch('fetchUsers')
                });
        },

        async updateUser({ commit }, user: IUsuario) {
            console.log(JSON.stringify(user))
            await axios.put(`${API_URL}/users/${user.id}`, JSON.stringify(user), {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
                .then((response) => {
                    console.log(response.data)
                })
        },

        async addUser({ commit }, user: IUsuario) {
            console.log(JSON.stringify(user))
            await axios.post(`${API_URL}/users`, JSON.stringify(user), {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
                .then((response) => {
                    console.log(response.data)
                })
        },

    },

    mutations: {
        [LISTA_USUARIOS](state, usuarios: IUsuario[]) {
            state.usuarios = usuarios;
        },

        [NOTIFICAR](state, novaNotificacao: INotificacao) {

            novaNotificacao.id = new Date().getTime()
            state.notificacoes.push(novaNotificacao)

            setTimeout(() => {
                state.notificacoes = state.notificacoes.filter(notificacao => notificacao.id != novaNotificacao.id)
            }, 3000)
        }
    }
})

export function useStore(): Store<Estado> {
    return vuexUseStore(key)
}