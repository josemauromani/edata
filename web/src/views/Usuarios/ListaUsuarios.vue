<template>
  <section>
    <router-link to="/usuarios/novo" class="button">
      <span class="icon is-small">
        <i class="fa fa-plus"></i>
      </span>
      <span>Novo Usuario</span>
    </router-link>
  </section>
  <table class="table is-fullwidth">
    <thead>
      <tr>
        <th>ID</th>
        <th>Nome</th>
        <th>Sobrenome</th>
        <th>CPF</th>
        <th>Data Nascimento</th>
        <th>Acoes</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="usuario in usuarios" :key="usuario.id">
        <td>{{ usuario.id }}</td>
        <td>{{ usuario.nome }}</td>
        <td>{{ usuario.sobrenome }}</td>
        <td>{{ usuario.cpf }}</td>
        <td>{{ usuario.dataNascimento }}</td>
        <td>
          <router-link :to="`/usuarios/${usuario.id}`" class="button">
            <span class="icon is-small">
              <i class="fas fa-pencil-alt"></i>
            </span>
          </router-link>
          <button class="button ml-2 is-danger" @click="excluir(usuario.id)">
            <span class="icon is-small">
              <i class="fas fa-trash"></i>
            </span>
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script lang="ts">
import { useStore } from "@/store";
import { computed, defineComponent } from "vue";
import { EXCLUIR_USUARIO, LISTA_USUARIOS } from "@/store/tipo-mutacoes";

export default defineComponent({
  name: "ListaUsuarios",
  methods: {
    excluir(id: string) {
      this.store.dispatch('deleteUser', id)
    },
  },
  setup() {
    const store = useStore()
    store.dispatch('fetchUsers')
    return {
      usuarios: computed(() => store.state.usuarios),
      store,
    };
  },
});
</script>
